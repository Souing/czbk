using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentAPI2
{
    class Program
    {
        static void Main(string[] args)
        {
            using (MyContext ctx = new MyContext())
            {
                
                Teacher t1 = new Teacher();
                t1.Name = "李老师";

                Student s1 = new Student() { Name="小明"};
                Student s2 = new Student() { Name = "小红" };
                s1.Teachers.Add(t1);
                s2.Teachers.Add(t1);

                ctx.Students.Add(s1);
                ctx.Students.Add(s2);
                /*
                Teacher t1 = ctx.Teachers.Single(t=>t.Name=="李老师");
                Student sTom = ctx.Students.Single(s=>s.Name=="tom");
                t1.Students.Remove(sTom);*/
                //t1.Students.Add(sTom);
                //sTom.Teachers.Add(t1);
                ctx.SaveChanges();
            }

            Console.WriteLine("ok");
            Console.ReadKey();
        }
    }
}
