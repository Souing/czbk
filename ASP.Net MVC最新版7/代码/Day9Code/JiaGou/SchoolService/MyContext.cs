using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EFEntities
{
    public class MyContext:DbContext
    {
        public MyContext():base("name=conn1")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.AddFromAssembly(
                Assembly.GetExecutingAssembly()
                );
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<MinZu> MinZus { get; set; }
        public DbSet<Class> Classes { get; set; }
    }
}
