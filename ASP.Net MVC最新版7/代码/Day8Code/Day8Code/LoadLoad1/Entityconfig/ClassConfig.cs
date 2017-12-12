using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentAPI1.Entityconfig
{
    class ClassConfig:EntityTypeConfiguration<Class>
    {
        public ClassConfig()
        {
            ToTable("T_Classes");
        }
    }
}
