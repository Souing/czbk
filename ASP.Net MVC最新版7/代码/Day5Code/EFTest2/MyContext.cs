using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTest2
{
    class MyContext:DbContext
    {
        public MyContext():base("name=conn1")
        {

        }
        public DbSet<Person> Persons { get; set; }
    }
}
