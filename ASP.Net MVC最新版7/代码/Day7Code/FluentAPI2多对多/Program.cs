using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentAPI2多对多
{
    class Program
    {
        static void Main(string[] args)
        {
            Teacher t1 = new Teacher();
            t1.Name = "文语文";

            Teacher t2 = new Teacher();
            t2.Name = "李树学";

            Student s1 = new Student();
            s1.Name = "tom";

            Student s2 = new Student();
            s2.Name = "jim";

            Student s3 = new Student();
            s3.Name = "lily";

            using (MyContext ctx = new MyContext())
            {
                /*
                t1.Students.Add(s1);
                t1.Students.Add(s2);

                t2.Students.Add(s2);
                t2.Students.Add(s3);

                ctx.Teachers.Add(t1);
                ctx.Teachers.Add(t2);
                */
                /*
                s1.Teachers.Add(t1);
                s1.Teachers.Add(t2);

                t1.Students.Add(s1);
                t1.Students.Add(s2);

                t2.Students.Add(s1);
                t2.Students.Add(s2);

                s2.Teachers.Add(t1);
                s2.Teachers.Add(t2);

                ctx.Students.Add(s1);
                ctx.Students.Add(s2);*/


                Teacher t = ctx.Teachers.First();
                t.Students.Remove(t.Students.First());

                ctx.SaveChanges();
            }

                Console.WriteLine("ok");
            Console.ReadKey();
        }
    }
}
