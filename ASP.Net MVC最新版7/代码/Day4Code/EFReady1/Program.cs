using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace EFReady1
{
    class Program
    {
        static void Main(string[] args)
        {
            var s0 = new Person { Name = "tom", Age = 3, Gender = true, Salary = 6000 };
            var s1 = new Person { Name = "jerry", Age = 8, Gender = true, Salary = 5000 };
            var s2 = new Person { Name = "jim", Age = 3, Gender = true, Salary = 3000 };
            var s3 = new Person { Name = "lily", Age = 5, Gender = false, Salary = 9000 };
            var s4 = new Person { Name = "lucy", Age = 6, Gender = false, Salary = 2000 };
            var s5 = new Person { Name = "kimi", Age = 5, Gender = true, Salary = 1000 };

            List<Person> list = new List<Person>();
            list.Add(s0);
            list.Add(s1);
            list.Add(s2);
            list.Add(s3);
            list.Add(s4);
            list.Add(s5);
            Teacher t1 = new Teacher { Name = "如鹏网张老师" };
            t1.Students.Add(s1);
            t1.Students.Add(s2);

            Teacher t2 = new Teacher { Name = "如鹏网刘老师" };
            t2.Students.Add(s2);
            t2.Students.Add(s3);
            t2.Students.Add(s5);

            Teacher[] teachers = { t1, t2 };

            /*
            Console.WriteLine(teachers.Any());
            List<int> list1 = new List<int>();
            Console.WriteLine(list1.Any());

            Console.WriteLine(teachers.Any(t=>t.Name== "如鹏网张老师"));
            */
            //var list1 = list.OrderByDescending(p=>p.Salary);
            // var list1 = list.OrderBy(p => p.Salary);
            //var list1 = list.OrderBy(p => p.Age).OrderBy(p=>p.Salary);
            /*
            var list1 = list.OrderBy(p => p.Age).ThenBy(p => p.Salary).ThenByDescending(p=>p.Gender);
            foreach (Person p1 in list1)
            {
                Console.WriteLine(p1);
            }*/
            var list1 = list.Skip(2).Take(300);
            foreach(var p1 in list1)
            {
                Console.WriteLine(p1);
            }
            Console.ReadKey();
        }
    }
}
