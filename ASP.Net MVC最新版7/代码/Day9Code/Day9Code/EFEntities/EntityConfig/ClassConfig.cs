using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFEntities.EntityConfig
{
    class ClassConfig : EntityTypeConfiguration<Class>
    {
        public ClassConfig()
        {
            ToTable("T_Classes");
            Property(e => e.Name).HasMaxLength(20).IsRequired();

        }
    }
}
