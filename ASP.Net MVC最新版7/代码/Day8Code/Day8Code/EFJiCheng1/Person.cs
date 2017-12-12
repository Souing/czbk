using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFJiCheng1
{
    public abstract class Person:BaseEntity
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
