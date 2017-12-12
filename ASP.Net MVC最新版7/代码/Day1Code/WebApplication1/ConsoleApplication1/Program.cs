using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Dynamic;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Person p1 = new Person();
            /*
            dynamic p1 = new Person();
            p1.Name = "rupeng";
            p1.Age = 88;
            p1.AA = 99;
            p1.Hello();*/
            /*
            dynamic p1 = new ExpandoObject();
            p1.AA = 555;
            p1.Name = "fadfafdadf";
            Console.WriteLine(p1.AA);
            p1.AA = "rupeng";
            Console.WriteLine(p1.AA);

            dynamic i1 = "adfasdfads";
            i1 = true;
            */
            var i = 3;//编译器会把var替换成合适的类型去编译
            Console.WriteLine(i);
            //i = true;
            Console.WriteLine(i);

            //定义一个类MyP{public String Name{get;set;}  public int Age{get;set;}}
            //MyP p = new MyP();
            //p.Name="rupeng";
            //p.Age=88;
            var p = new { Name="rupeng",Age=88};
            //p.Name = "fadfads";
            Console.WriteLine(p.Name);
            Console.ReadKey();
        }
    }

    class Person
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public void Hello()
        {
            Console.WriteLine("age="+Age+",Name="+Name);
        }
    }
}
