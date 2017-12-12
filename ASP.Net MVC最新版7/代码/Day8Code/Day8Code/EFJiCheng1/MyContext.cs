using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFJiCheng1
{
    class MyContext:DbContext
    {
        public MyContext():base("name=conn1")
        {
            //Database.SetInitializer<MyContext>(null);
        }

        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Class> Classes { get; set; }
    }
}
