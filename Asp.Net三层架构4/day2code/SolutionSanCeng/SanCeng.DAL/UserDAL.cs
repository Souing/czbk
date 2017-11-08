using SanCeng.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanCeng.DAL
{
    public class UserDAL
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="phoneNum"></param>
        /// <param name="age"></param>
        /// <returns></returns>
        public long Add(string userName,string password,string phoneNum,int? age)
        {
            //ADO.Net对于SqlParameter参数，如果想赋值Null，则必须传递DBNull.Value，不能穿null
            //否则运行就会报错“没有给@Age提供值”
            object obj = SqlHelper.ExecuteScalar("insert into T_Users(UserName,Password,PhoneNum,Age,IsDeleted) output inserted.Id values(@UserName,@Password,@PhoneNum,@Age,0)",
                new SqlParameter("@UserName", userName), new SqlParameter("@Password", password),
                //new SqlParameter("@PhoneNum", phoneNum), new SqlParameter("@Age", age==null?(object)DBNull.Value:age));
                new SqlParameter("@PhoneNum", phoneNum), new SqlParameter("@Age", age??(object)DBNull.Value));//a??b，如果a为null，则表达式的值为b，否则为a
            return Convert.ToInt64(obj);//return (long)obj;
        }

        /// <summary>
        /// 软删除id为主键的数据
        /// </summary>
        /// <param name="id"></param>
        public void Delete(long id)
        {
            SqlHelper.ExecuteNonQuery("Update T_users Set IsDeleted=1 where Id=@Id",new SqlParameter("@Id",id));
        }

        private User ToUser(DataRow row)
        {
            User user = new User();
            user.Id = (long)row["Id"];
            // user.Age = (int?)row["Age"];
            user.Age = row.IsNull("Age") ? null : (int?)row["Age"];//!!!
            user.IsDeleted = (bool)row["IsDeleted"];
            user.Password = (string)row["Password"];
            user.PhoneNum = (string)row["PhoneNum"];
            user.UserName = (string)row["UserName"];
            return user;
        }

        public void Update(User user)
        {
            SqlHelper.ExecuteNonQuery("Update T_Users set UserName=@UserName,Password=@Password,PhoneNum=@PhoneNum,Age=@Age where Id=@Id",
                new SqlParameter("@UserName", user.UserName), new SqlParameter("@Password", user.Password),
                //new SqlParameter("@PhoneNum", phoneNum), new SqlParameter("@Age", age==null?(object)DBNull.Value:age));
                new SqlParameter("@PhoneNum", user.PhoneNum), new SqlParameter("@Age", user.Age ?? (object)DBNull.Value),
                new SqlParameter("@Id",user.Id)
                );
        }

        public User GetByUserName(string userName)
        {
            DataTable table = SqlHelper.ExecuteQuery("select * from T_Users where UserName=@UserName",
                new SqlParameter("UserName",userName));
            if(table.Rows.Count<=0)
            {
                return null;
            }
            else if(table.Rows.Count>1)
            {
                throw new ApplicationException("用户名重复啦！");
            }
            else
            {
                return ToUser(table.Rows[0]);
            }
        }

        //返回一个User的对象，而不是DataRow，这样用起来更方便
        public User GetById(long id)
        {
            //ORM：
            DataTable table = 
                SqlHelper.ExecuteQuery("select * from T_Users where Id=@Id", new SqlParameter("@Id", id));
            if(table.Rows.Count<=0)
            {
                return null;//没有找到id对应的数据
            }
            else if(table.Rows.Count>1)//你认为不可能有多条数据，那么就检查一下，而不是“视而不见”,防御式编程
            {
                throw new ApplicationException("找到多条id="+id+"的数据");
            }
            else
            {
                DataRow row = table.Rows[0];
                /*
                User user = new User();
                user.Id = (long)row["Id"];
               // user.Age = (int?)row["Age"];
                user.Age=row.IsNull("Age")?null:(int?)row["Age"];//!!!
                user.IsDeleted = (bool)row["IsDeleted"];
                user.Password = (string)row["Password"];
                user.PhoneNum = (string)row["PhoneNum"];
                user.UserName = (string)row["UserName"];
                return user;*/
                return ToUser(row);
            }
        }

        /// <summary>
        /// 返回所有未软删除的数据
        /// </summary>
        /// <returns></returns>
        //public List<User> GetAll()
        public IEnumerable<User> GetAll()
        {
            DataTable dt = SqlHelper.ExecuteQuery("select * from T_Users where IsDeleted=0");
            List<User> list = new List<User>();
            foreach(DataRow row in dt.Rows)
            {
                /*
                User user = new User();
                user.Id = (long)row["Id"];
                // user.Age = (int?)row["Age"];
                user.Age = row.IsNull("Age") ? null : (int?)row["Age"];//!!!
                user.IsDeleted = (bool)row["IsDeleted"];
                user.Password = (string)row["Password"];
                user.PhoneNum = (string)row["PhoneNum"];
                user.UserName = (string)row["UserName"];
                list.Add(user);*/
                list.Add(ToUser(row));
            }
            return list;
        }
    }
}
