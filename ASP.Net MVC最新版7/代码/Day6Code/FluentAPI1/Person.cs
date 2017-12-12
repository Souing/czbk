using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentAPI1
{
    public class Person
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDateTime { get; set; }
        public int? Age { get; set; }

        public override string ToString()
        {
            return "Id="+Id+",Name="+Name+",CreateDT="+CreateDateTime+",Age="+Age;
        }
    }
}
