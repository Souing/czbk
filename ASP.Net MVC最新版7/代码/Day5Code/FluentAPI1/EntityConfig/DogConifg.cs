using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentAPI1.EntityConfig
{
    class DogConifg:EntityTypeConfiguration<Dog>
    {
        public DogConifg()
        {
            this.ToTable("T_Dogs");
        }

    }
}
