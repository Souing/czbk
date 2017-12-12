using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentAPI2
{
    class StudentConfig:EntityTypeConfiguration<Student>
    {
        public StudentConfig()
        {
            ToTable("T_Students");
            this.Property(e => e.Name).HasMaxLength(30).IsRequired();
            this.HasMany(e => e.Teachers).WithMany(e=>e.Students).Map(m => m.ToTable("T_StudentTeachers")
                  .MapLeftKey("StudentId").MapRightKey("TeacherId"));
        }
    }
}
