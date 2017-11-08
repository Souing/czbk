using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormTest1
{
    class Person
    {
        public Person(long id,string name,int age)
        {
            this.Id = id;
            this.Name = name;
            this.Age = age;
        }
        public long Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
