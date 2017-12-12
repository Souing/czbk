using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FluentAPI1
{
    class TestContext:DbContext
    {
        public TestContext():base("name=conn1")
        {
            Database.SetInitializer<TestContext>(null);
        }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Student> Students { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            Assembly asm = Assembly.GetExecutingAssembly();
            modelBuilder.Configurations.AddFromAssembly(asm);
        }
    }
}
