using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFReady1
{
    public class Teacher
    {
        public Teacher()
        {
            this.Students = new List<Person>();
        }
        public string Name { get; set; }
        public List<Person> Students { get; set; }
    }

}
