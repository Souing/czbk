using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFReady1
{
    //学生
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public bool Gender { get; set; }
        public int Salary { get; set; }

        public override string ToString()
        {
            return string.Format("Name={0},Age={1},Gender={2},Salary={3}",
                Name, Age, Gender, Salary);
        }
    }

}
