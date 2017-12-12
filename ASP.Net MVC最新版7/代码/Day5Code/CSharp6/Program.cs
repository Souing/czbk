using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp6
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Person p1 = new Person();
            //Console.WriteLine(p1.Age);
            string s1 = nameof(p1);//"p1"            
            Console.WriteLine(s1);
            string s2 = nameof(Person);
            Console.WriteLine(s2);
            string s3 = nameof(p1.Age);//"Age"
            string s4 = nameof(p1.SayHello);
            Console.WriteLine(s4);
            Console.WriteLine(s3);

            string s5 = nameof(Person.Age);//"Age"
            Console.WriteLine(s5);*/

            /*
            int? i = null;
            //int j = i ?? 3;
            int j = (i == null ? 3 : (int)i);
            Console.WriteLine(j);
            */
            string s8 = null;
             string s9 = s8?.Trim();
            //string s9 = (s8==null?null:s8.Trim());
            //string s9 = s8.Trim();
            Console.WriteLine(s9==null);
            Console.WriteLine(s9);
            Console.ReadKey();
        }
    }

    class Person
    {
        /*
        public Person()
        {
            this.Age = 6;
        }*/
        public int Age { get; set; } = 6;

        public string Passord { get; set; }

        public string Passord2 { get; set; }

        public void SayHello()
        {
            Console.WriteLine("我"+Age+"岁了");
        }
    }
}
