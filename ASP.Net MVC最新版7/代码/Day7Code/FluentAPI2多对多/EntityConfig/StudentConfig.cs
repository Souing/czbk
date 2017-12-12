using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentAPI2多对多.EntityConfig
{
    class StudentConfig:EntityTypeConfiguration<Student>
    {
        public StudentConfig()
        {
            this.ToTable("T_Students");
            this.Property(e => e.Name)
                .HasMaxLength(30).IsRequired();


        }
    }
}
