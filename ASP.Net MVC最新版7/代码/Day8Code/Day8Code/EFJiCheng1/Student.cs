using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFJiCheng1
{
    public class Student: Person
    {
        public string StuNo { get; set; }
        public virtual Class Class { get; set; }
    }
}
