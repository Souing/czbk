using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentAPI1
{
    class PersonConfig:EntityTypeConfiguration<Person>
    {
        public PersonConfig()
        {
            ToTable("T_Persons");
            //this.HasKey(e=>e.pId);
            this.Ignore(e => e.Age2);
            /*
            this.Property(e => e.Name).HasMaxLength(30);
            //this.Property(e => e.Name).IsRequired();
            this.Property(e => e.Name).IsOptional();
            this.Property(e => e.Name).IsFixedLength();
            this.Property(e => e.Name).IsUnicode(false);*/
            //asp.net mvc,.net core UseMysql(),UseSQLserver()
            //Where().Task().Skip().Select()
            this.Property(e => e.Name).HasMaxLength(30).IsRequired()
                .IsFixedLength().IsUnicode(false);
           // this.Property(e => e.Age).IsRequired().HasColumnName("Age");

            this.Property(e => e.Age).HasColumnName("NianLing");
        }
    }
}
