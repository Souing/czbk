using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentAPI2
{
    class TeacherConfig:EntityTypeConfiguration<Teacher>
    {
        public TeacherConfig()
        {
            ToTable("T_Teachers");
            this.Property(e => e.Name).HasMaxLength(30).IsRequired();
        }
    }
}
