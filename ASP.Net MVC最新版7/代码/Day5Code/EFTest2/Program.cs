using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTest2
{
    class Program
    {
        static void Main(string[] args)
        {
            using (MyContext ctx = new MyContext())
            {
                Person p1 = new Person();
                p1.CreateDateTime = DateTime.Now;
                //p1.Name = "如鹏网";
                ctx.Persons.Add(p1);
                ctx.SaveChanges();
            }
        }
    }
}
