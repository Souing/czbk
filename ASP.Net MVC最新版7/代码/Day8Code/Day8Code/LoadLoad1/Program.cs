using FluentAPI1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace LoadLoad1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Student s;
            String className;
            using (TestContext ctx = new TestContext())
            {
                 s = ctx.Students.First();
                //s = ctx.Students.Include(e => e.Class).First();
                className = s.Class.Name;
            }
            //Console.WriteLine(s.Class.Name);
            Console.WriteLine(className);
            */
            using (TestContext ctx = new TestContext())
            {
                ctx.Database.Log = (sql) => {
                    Console.WriteLine(sql);
                };

                //ExecuteReader()  DataReader
                //ado.net sqlserver默认情况下一个连接中只能有一个在执行的DataReader
                //foreach (var s in ctx.Students.ToList())
                //foreach (var s in ctx.Students)
                foreach (var s in ctx.Students.Include(e=>e.Class))
                {
                    Console.WriteLine(s.Name);
                    Console.WriteLine(s.Class.Name);
                }
            }

            Console.WriteLine("ok");
            Console.ReadKey();
        }
        static void Main1(string[] args)
        {
            using (TestContext ctx = new TestContext())
            {

                ctx.Database.Log = (sql) => {
                    Console.WriteLine(sql);
                };

                //需要using System.Data.Entity;才可以用lambda表达式的Include写法
                Student s = ctx.Students.Include(e=>e.Class).First();
                // Student s = ctx.Students.Include("Class").First();
                // Student s = ctx.Students.Include(nameof(Student.Class)).First();
                Console.WriteLine(s.Name);
                //设置virtual之后s指向的对象并不是Student类的对象，而是Student类的子类的对象
                //去掉virtual之后s指向的就是Student类的对象
                Console.WriteLine(s.GetType());//获得s指向对象的类型

                var c = s.Class;//LazyLoad（延迟加载，懒加载，惰性加载）
                //用到相关数据的时候才去加载
                /*
                StudentModel sm = new StudentModel();
                sm.Age = s.Age;
                sm.ClassId = s.ClassId;
                sm.ClassName = s.Class.Name;
                sm.Name = s.Name;
                sm.Id = s.Id;
                */
                Console.WriteLine(c.Name);
            }
            Console.WriteLine("ok");
            Console.ReadKey();

        }

        [Serializable]
        public class StudentModel
        {
            public long Id { get; set; }
            public string Name { get; set; }
            public long ClassId { get; set; }
            public string ClassName { get; set; }
            public int Age { get; set; }
        }
    }

   
}
