[TOC]

#  Ado.Net

## 1. SqlBulkCopy 

```C#
			using (SqlConnection conn = SqlHelper.CreateConnection())
            using (SqlTransaction tx = conn.BeginTransaction())
            {
                try
                {
                    using (SqlBulkCopy bulkCopy = new SqlBulkCopy(conn, SqlBulkCopyOptions.Default, tx))
                    {

                        bulkCopy.DestinationTableName = "T_Student";
                        bulkCopy.ColumnMappings.Add("StuName", "StuName");
                        bulkCopy.ColumnMappings.Add("StuAge", "StuAge");

                        bulkCopy.WriteToServer(dt);
                        dt.Dispose();
                        dt = null;
                    }
                    tx.Commit();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex + " 保存数据失败");
                    tx.Rollback();

                }

            }
```

## 2. MySql批量插入

```C#
            Stopwatch sw = new Stopwatch();
            sw.Start();
            using (MySqlConnection conn = new MySqlConnection("server=127.0.0.1;database=study1;uid=root;pwd=root"))
            {
                conn.Open();
                using (MySqlCommand cmd = conn.CreateCommand())
                {
                    //一条SQL数据的长度有限
                    //拼接出1000条数据就批量插入一次
                    List<string> listSql = new List<string>();
                    for (int i = 0; i < 100000; i++)
                    {
                        listSql.Add("('test" + i + "','" + i + "')");
                        if (listSql.Count > 1000)
                        {
                            string sql = "insert into t_users(UserName,Password) values" + string.Join(",", listSql);
                            cmd.CommandText = sql;
                            cmd.ExecuteNonQuery();
                            listSql.Clear();
                        }
                    }
                    if (listSql.Count > 0)
                    {
                        //处理残留的数据
                        string sql1 = "insert into t_users(UserName,Password) values" + string.Join(",", listSql);
                        cmd.CommandText = sql1;
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            sw.Stop();
```

## 3. SqlServer事物

```
using (SqlConnection conn = new SqlConnection(connstr))
            {
                conn.Open();
                using (SqlTransaction tx = conn.BeginTransaction())
                {
                    try
                    {
                        //using是保证资源一定会被回收的，离开using范围后自动调用Dispose方法（无论是否有异常）
                        //using==try...finally...
                        //using不会进行异常的catch
                        using (SqlCommand cmd1 = conn.CreateCommand())
                        using (SqlCommand cmd2 = conn.CreateCommand())
                        {
                            cmd1.Transaction = tx;//在SQLServer中必须把BeginTransaction返回的对象赋值给SqlCommand的
                            //Transaction属性
                            cmd1.CommandText = "insert into T_Persons(Name,Age) values('a',1)";
                            cmd1.ExecuteNonQuery();
                            cmd2.Transaction = tx;
                            cmd2.CommandText = "insert into T_Persons(Name,Age) values('b',2)";
                            cmd2.ExecuteNonQuery();
                        }
                        tx.Commit();
                    }
                    catch (Exception ex)
                    {
                        tx.Rollback();
                    }
                }
            }
```

## 4. Like和In中查询参数的问题  

```C#
            Console.WriteLine("请输入要查询的姓名");
            string name = Console.ReadLine();
            //'%@Name%'是一个整体，无法“部分当成查询参数”
            //DataTable dt =  SqlHelper.ExecuteQuery("select * from T_Persons where Name like '%@Name%'",
            //DataTable dt = SqlHelper.ExecuteQuery("select * from T_Persons where Name like '%'+@Name+'%'",
            //new SqlParameter("@Name",name));
            DataTable dt = SqlHelper.ExecuteQuery("select * from T_Persons where Name like @Name",
                new SqlParameter("@Name", "%" + name + "%"));
            foreach (DataRow row in dt.Rows)
            {
                Console.WriteLine(row["Name"]);
            }
            string line = Console.ReadLine();
            foreach (char ch in line)
            {
                if (!char.IsDigit(ch) && ch != ',')
                {
                    Console.WriteLine("输入非法");
                    Console.ReadKey();
                    return;
                }
            }

            //DataTable dt = SqlHelper.ExecuteQuery("select * from T_Persons where Age in(@Age)",
            //  new SqlParameter("@Age",line));
            // DataTable dt = SqlHelper.ExecuteQuery("select * from T_Persons where Age in(" + line+")");

            DataTable dt = SqlHelper.ExecuteQuery("exec('select * from T_Persons where Age in('+@Age+')')",
                new SqlParameter("@Age", line));
            foreach (DataRow row in dt.Rows)
            {
                Console.WriteLine(row["Name"] + "=" + row["Age"]);
            }
            Console.WriteLine(sw.ElapsedMilliseconds);
```

```
			是由Java一个有想法的人提出来的
			string[] parameters = new string[]{"1","2","3"};
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from itcast_user where id in(");
            
            for (int i = 0; i < parameters.Length; i++)
            {
                sb.Append("@"+i);
                sb.Append(",");
            }
            //remove last 逗号
            sb.Remove(sb.Length - 1, 1);
            sb.Append(")");

            string conn_str = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
            DataTable dt = new DataTable();
            using (MySqlConnection conn = new MySqlConnection(conn_str))
            {
                using (MySqlCommand command = conn.CreateCommand())
                {
                    conn.Open();
                    command.CommandText = sb.ToString();
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        string parameterName = "@"+i;
                        command.Parameters.Add(new MySqlParameter { ParameterName = parameterName, Value = parameters[i]});
                    }
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        dt.Load(reader);
                    }

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataRow row = dt.Rows[i];
                        long id = (long)row["id"];
                        Console.WriteLine("id====" + id);
                    }
                    Console.ReadKey();
             
                }
            }
```

## 5. Sql和MySql输出增加Insert.Id

### 5.1 Sql输出

```sql
 Insert into t1(...) output inserted.Id values(.........)
```

### 5.2 MySql输出

```mysql
insert into t_users(UserName,Password) values('我几时我','123');select last_insert_id()
```

## 9. SqlServer和MySql事物区别

> 在SQLServer中必须把BeginTransaction返回的对象赋值给SqlCommand的

