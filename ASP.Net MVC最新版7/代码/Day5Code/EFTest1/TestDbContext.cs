using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTest1
{
    class TestDbContext:DbContext
    {
        public TestDbContext():base("name=connStr")
        {

        }

        public DbSet<Person> Persons { get; set; }
    }
}
