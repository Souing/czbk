using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentAPI1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (TestContext ctx = new TestContext())
            {
                ctx.Database.Log = (sql) => {
                    Console.WriteLine(sql);
                };
                /*
                Class clz = new Class();
                clz.Name = "五年三班";
                ctx.Classes.Add(clz);
                Student s1 = new Student();
                s1.Age = 8;
                s1.Class = clz;
                s1.Name = "方文山";
                ctx.Students.Add(s1);
                ctx.SaveChanges();*/
                /*
                Student s1 = ctx.Students.First();
                Console.WriteLine(s1.Name);
                Class clz = s1.Class;*/

                /*
                Student s1 = new Student();
                s1.Age = 6;
                s1.Name = "tom";
                ctx.Students.Add(s1);*/
                //Class clz = ctx.Classes.First();
                /*
                foreach(Student s in clz.Students)
                {
                    Console.WriteLine(s.Name);
                }*/

                //数据库化思维。
                /*
                foreach(Student s in 
                    ctx.Students.Where(s => s.ClassId == clz.Id))
                {
                    Console.WriteLine(s.Name);
                }*/

                /*
                Class clz = new Class();
                clz.Name = "1年1班";
                ctx.Classes.Add(clz);
                Student s1 = new Student();
                s1.Age = 8;
                s1.Class = clz;
                s1.Name = "小朋友";
                clz.Students.Add(s1);
                //ctx.Students.Add(s1);
                ctx.SaveChanges();
                */
                /*
                foreach(var clz in ctx.Classes.ToList())
                {
                    foreach(var s in clz.Students)
                    {
                        Console.WriteLine(clz.Name+"-"+s.Name);
                    }
                }*/

                /*
                Class clz = ctx.Classes.First();
                foreach (Student s in clz.Students)
                //foreach(Student s in ctx.Students.Where(e=>e.ClassId==clz.Id))
                {
                    Console.WriteLine(s.Name);
                }
                */

                Class c1 = new Class();
                c1.Name = "六年一班";

                Class c2 = new Class();
                c2.Name = "小升初状元特训班";

                Student s1 = new Student();
                s1.Name = "王大力";
                s1.Age = 18;

                s1.Class = c1;
                s1.XZClass = c2;

                ctx.Classes.Add(c1);
                ctx.Classes.Add(c2);
                ctx.Students.Add(s1);

                ctx.SaveChanges();

                // ctx.SaveChanges();

            }
            Console.WriteLine("ok");
                Console.ReadKey();
        }
            static void Main2(string[] args)
        {
            using (TestContext ctx = new TestContext())
            {
                ctx.Database.Log = (sql) =>
                {
                    Console.WriteLine(sql);
                };
                Person p = new Person();
                p.Age = 30;
                p.Name = "mayun333333333333333333333333333333333333333333333333333333333333333333333333333333333";
                ctx.Persons.Add(p);
                try
                { 
                ctx.SaveChanges();
                }
                catch(DbEntityValidationException valEx)
                {
                    foreach(DbEntityValidationResult err in valEx.EntityValidationErrors)
                    {
                        foreach(DbValidationError ve in err.ValidationErrors)
                        {
                            Console.WriteLine("错误："+ve.PropertyName+","+ve.ErrorMessage);
                        }
                    }
                }
            }

            Console.WriteLine("ok");
            Console.ReadKey();
        }
    }
}
