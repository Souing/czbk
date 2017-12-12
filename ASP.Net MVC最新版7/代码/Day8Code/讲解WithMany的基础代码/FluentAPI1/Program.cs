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
                var s =  ctx.Students.First();
                Console.WriteLine(s.Name);
                var c = s.Class;
                Console.WriteLine(c.Name);                           
            }
            Console.WriteLine("ok");
            Console.ReadKey();
        }
    }
}
