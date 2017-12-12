using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentAPI1.EntityConfig
{
    class PersonConfig:EntityTypeConfiguration<Person>
    {
        public PersonConfig()
        {
            this.ToTable("T_Persons");
        }
    }
}
