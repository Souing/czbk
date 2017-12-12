using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentAPI1
{
    public class Class
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Student> Students { get; set; } = new List<Student>();
    }
}
