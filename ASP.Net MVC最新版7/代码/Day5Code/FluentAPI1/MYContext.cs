using FluentAPI1.EntityConfig;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FluentAPI1
{
    class MYContext:DbContext
    {
        public MYContext():base("name=conn1")
        {

        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Dog> Dogs { get; set; }

        protected override void OnModelCreating(DbModelBuilder 
            modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //从某个程序集中加载所有继承自EntityTypeConfiguration
            //类到配置中
            /*
            modelBuilder.Configurations.AddFromAssembly(
            Assembly.Load("ModelConfig"));*/

            modelBuilder.Configurations.AddFromAssembly(
                Assembly.GetExecutingAssembly());
            //modelBuilder.Entity<Person>().ToTable("T_Persons");
            //modelBuilder.Configurations.Add(new PersonConfig());
        }
    }
}
