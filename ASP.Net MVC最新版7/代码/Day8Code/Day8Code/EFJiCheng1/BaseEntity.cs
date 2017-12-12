using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFJiCheng1
{
    public abstract class BaseEntity
    {
        public long Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreateDateTime { get; set; } = DateTime.Now;
        public DateTime? DeleteDateTime { get; set; }
    }
}
