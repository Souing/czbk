using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RuupengORM
{
    class RPorm
    {
        //约定：1、类名要和表名一样
        //2、字段名和数据库列名一样
        //3、主键的名字必须叫Id，必须是自动递增，int类型
        public static void Insert(Object obj)
        {
            //获得obj对象的类名
            Type type = obj.GetType();//typeof(Person)
            string className = type.Name;//类名:Person
            PropertyInfo[] propInfos = type.GetProperties();//3
            //列名的数组
            string[] propNames = new string[propInfos.Length-1];//排除掉Id
            string[] paramNames = new string[propInfos.Length-1];
            MySqlParameter[] sqlParameters = new MySqlParameter[propInfos.Length - 1];
            int count = 0;
            //for (int i = 0; i < propInfos.Length; i++)
            foreach (PropertyInfo propInfo in propInfos)
            {
                //PropertyInfo propInfo = propInfos[i];
                string propName = propInfo.Name;
                if (propName != "Id")//排除Id
                {
                    propNames[count] = propName;
                    paramNames[count] = "@" + propName;
                    MySqlParameter sqlParameter = new MySqlParameter();
                    sqlParameter.ParameterName = "@" + propName;
                    sqlParameter.Value = propInfo.GetValue(obj);//取obj对象的propInfo属性的值
                    sqlParameters[count] = sqlParameter;
                    count++;
                }
            }
           // string colnames = string.Join(",", propNames);
            //拼接生成Insert语句
            StringBuilder sbSQL = new StringBuilder();
            //Insert into Person(Name,Age) values(@Name,@Age)
            sbSQL.Append("Insert into ").Append(className).Append("(");
            sbSQL.Append(string.Join(",", propNames)).Append(")");
            sbSQL.Append(" values(").Append(string.Join(",", paramNames))
                .Append(")");

            RupengORM.MySqlHelper.ExecuteNonQuery(sbSQL.ToString(),
                sqlParameters);//params可变长度参数本质上就是一个数组
        }

        public static T SelectById<T>(int id) where T:new()//泛型约束，约束T必须有一个无参的构造函数
        {
            Type type = typeof(T);//typeof(Person)
            string className = type.Name;
            string sql = "select * from " + className + " where Id=@Id";
            DataTable dt =
                RupengORM.MySqlHelper.ExecuteQuery(sql, new MySqlParameter("@Id", id));
            if (dt.Rows.Count <= 0)
            {
                //return null;//没有找到
                return default(T);//default()运算符用来获得类型的默认值
                //default(int)→0.default(bool)→false。default(Person)→null
            }
            else if (dt.Rows.Count > 1)
            {
                throw new Exception("粗大事了，查到多条Id=" + id + "的数据");
            }
            DataRow row = dt.Rows[0];
            //创建type类的一个对象
            //Object obj = Activator.CreateInstance(type);
            T obj = new T();
            //给obj对象的每一个属性（包括Id）赋值
            foreach (PropertyInfo propInfo in type.GetProperties())
            {
                string propName = propInfo.Name;//属性名就是列名
                object value = row[propName];//获取数据库中列的值
                propInfo.SetValue(obj, value);//给obj对象的propInfo属性赋值为value
            }
            return obj;
        }

        public static Object SelectById(Type type, int id)
        {
            string className = type.Name;
            string sql = "select * from "+className+" where Id=@Id";
            DataTable dt =
                RupengORM.MySqlHelper.ExecuteQuery(sql, new MySqlParameter("@Id", id));
            if (dt.Rows.Count <= 0)
            {
                return null;//没有找到
            }
            else if (dt.Rows.Count > 1)
            {
                throw new Exception("粗大事了，查到多条Id="+id+"的数据");
            }
            DataRow row = dt.Rows[0];
            //创建type类的一个对象
            Object obj = Activator.CreateInstance(type);

            //给obj对象的每一个属性（包括Id）赋值
            foreach (PropertyInfo propInfo in type.GetProperties())
            {
                string propName = propInfo.Name;//属性名就是列名
                object value = row[propName];//获取数据库中列的值
                propInfo.SetValue(obj, value);//给obj对象的propInfo属性赋值为value
            }
            return obj;
        }

        public static void DeleteById(Type type, int id)
        {
        }

        public static void Update(Object obj)
        {
            //生成Update语句
            //怎么知道哪一列被修改了呢？
            //把所有列都更新一下。反正不变还是不变。
            //Update Person set Name=@Name,Age=@Age where Id=@Id

            //从obj中拿到Id属性的值给到@Id
        }
    }
}
