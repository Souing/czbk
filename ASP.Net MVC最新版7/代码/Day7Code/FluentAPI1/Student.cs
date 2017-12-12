using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentAPI1
{
    public class Student
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long ClassId { get; set; }
        public long XZClassId { get; set; }
        public virtual Class Class { get; set; }
        public virtual Class XZClass { get; set; }
        public int Age { get; set; }
    }
}
