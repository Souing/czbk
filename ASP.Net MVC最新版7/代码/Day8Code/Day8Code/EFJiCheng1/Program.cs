using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EFJiCheng1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (MyContext ctx = new MyContext())
            {
                ctx.Database.Log = (sql) => {
                    Console.WriteLine(sql);
                };
                //Console.WriteLine(ctx.Teachers.Count());
                /*
                Teacher t1 = new Teacher { Age=18,Level=3,Name="tom",Salary=8000};
                Teacher t2 = new Teacher { Age = 28, Level =5, Name = "jerry", Salary = 9000 };
                ctx.Teachers.Add(t1);
                ctx.Set<Teacher>().Add(t2);

                ctx.SaveChanges();*/
                /*
                CommonCRUD<Teacher> crudt =
                    new CommonCRUD<Teacher>(ctx);
                
                
                var teachers = crudt.GetAll(0, 10);
                foreach(var t in teachers)
                {
                    Console.WriteLine(t.Name);
                }*/

                /*
                CommonCRUD<Student> cruds = new CommonCRUD<Student>(ctx);
                //cruds.MarkDeleted(1);
                Console.WriteLine(cruds.GetById(1).Name);
                //crudt.MarkDeleted(1);*/
                /*
                Class c1 = new Class { Name="三年二班"};
                Student s1 = new Student { Age=3,Class=c1,Name="张三",StuNo="1111"};
                Student s2 = new Student { Age = 3, Class = c1, Name = "李四", StuNo = "6666" };
                ctx.Students.Add(s1);
                ctx.Students.Add(s2);*/

                //对于IQueryable也可以调用Include（需要using System.Data.Entity;）
                CommonCRUD<Student> crud = new CommonCRUD<Student>(ctx);
                foreach(var s in crud.GetAll(0, 10).AsNoTracking().Include(s=>s.Class).Where(s=>s.Age>5))
                {
                    Console.WriteLine(s.Name);
                    Console.WriteLine(s.Class.Name);
                }

                ctx.SaveChanges();
            }
            Console.WriteLine("ok");
            Console.ReadKey();
        }
    }
}
