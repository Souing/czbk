using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentAPI2多对多.EntityConfig
{
    class TeacherConfig:EntityTypeConfiguration<Teacher>
    {
        public TeacherConfig()
        {
            this.ToTable("T_Teachers");
            this.Property(e => e.Name).HasMaxLength(30).IsRequired();
            this.HasMany(e => e.Students).WithMany(e=>e.Teachers)
                .Map(m => m.ToTable("T_TeacherStudentRelations")
                .MapLeftKey("TeacherId").MapRightKey("StudentId"));
        }
    }
}
