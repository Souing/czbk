using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTest1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (TestDbContext ctx = new TestDbContext())
            {
                Person p1 = new Person();
                p1.CreateDateTime = DateTime.Now;
                p1.Name = "rupeng.com";
                ctx.Persons.Add(p1);
                ctx.SaveChanges();
            }
        }
    }
}
