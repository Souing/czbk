using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDBFirst1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (test1Entities t1 = new test1Entities())
            {
                T_Classes clz = new T_Classes();
                clz.CreateDateTime = DateTime.Now;
                clz.DeleteDateTime = DateTime.Now;
                clz.IsDeleted = false;
                clz.Name = "rupeng";

                t1.T_Classes.Add(clz);
                t1.SaveChanges();
            }

        }
    }
}
