using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentAPI2
{
    public class Student
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
    }
}
