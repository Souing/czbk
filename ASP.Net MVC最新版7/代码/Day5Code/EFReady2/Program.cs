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

            int[] nums1 = { 3, 5, 8, 11, 15 };
            int[] nums2 = {  5, 7,8, 9, 15 };

            //var nums3 = nums1.Except(nums2);
            //var nums3 = nums1.Union(nums2);
            /*
            var nums3 = nums1.Intersect(nums2);
            foreach (int i in nums3)
            {
                Console.WriteLine(i);
            }*/
            /*
            IEnumerable<IGrouping<int,Person>> items =
                list.GroupBy(g => g.Age);
            foreach(IGrouping<int,Person> item in items)
            {
                Console.WriteLine("Key="+item.Key);
                foreach(Person p in item)
                {
                    Console.WriteLine(p);
                }
            }*/
            /*
            IEnumerable<IGrouping<bool, Person>> items = list.GroupBy(g => g.Gender);
            foreach (IGrouping<bool, Person> item in items)
            {
                Console.WriteLine("Key=" + item.Key+",count="+item.Count());
                foreach (Person p in item)
                {
                    Console.WriteLine(p);
                }
            }*/
            /*
            var items = list.GroupBy(g => g.Age);
            foreach(var item in items)
            {
                Console.WriteLine("key="+item.Key+",avg="+item.Average(p=>p.Salary)+
                    ",max="+item.Max(p=>p.Salary));
                //Min、Max、Sum、Count、Average
            }*/
            /*
            IEnumerable<Person> students =  teachers.SelectMany(t => t.Students);
            foreach(Person p in students)
            {
                Console.WriteLine(p);
            }*/
            List<Person> students = new List<Person>();
            foreach(var t in teachers)
            {
                foreach(var s in t.Students)
                {
                    students.Add(s);
                }
            }
            foreach (Person p in students)
            {
                Console.WriteLine(p);
            }
            Console.ReadKey();
        }
    }
}
