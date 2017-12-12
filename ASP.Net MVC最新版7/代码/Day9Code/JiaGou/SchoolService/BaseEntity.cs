using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFEntities
{
    public abstract class BaseEntity
    {
        public long Id { get; set; }
        public DateTime CreateDateTime { get; set; } = DateTime.Now;
    }
}
