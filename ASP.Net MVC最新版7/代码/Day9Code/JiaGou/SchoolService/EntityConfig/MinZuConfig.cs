using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFEntities.EntityConfig
{
    class MinZuConfig:EntityTypeConfiguration<MinZu>
    {
        public MinZuConfig()
        {
            ToTable("T_MinZus");
            Property(e => e.Name).HasMaxLength(20).IsRequired();

        }
    }
}
