using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentAPI1.Entityconfig
{
    class StudentConfig:EntityTypeConfiguration<Student>
    {
        public StudentConfig()
        {
            ToTable("T_Students");
            this.HasRequired(e => e.Class).WithMany()
                .HasForeignKey(e=>e.ClassId);
            this.HasOptional(e => e.XZClass).WithMany()
                .HasForeignKey(e => e.XZClassId);
        }
    }
}
