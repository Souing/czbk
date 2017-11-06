using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuupengORM
{
    class Program
    {
        static void Main(string[] args)
        {
            //ORM:EF(entity framework,Dapper,NHibernate)
            /*
            Person p1 = new Person();
            p1.Name = "rupeng";
            p1.Age = 7;
            RPorm.Insert(p1);*/      
      
            /*
            Dog d1 = new Dog();
            d1.Name = "孔老二";
            d1.Weight = 30;
            RPorm.Insert(d1);  
            */
            /*
            Person p1 = (Person)RPorm.SelectById(typeof(Person),1);
            Console.WriteLine(p1.Name+"的年龄是"+p1.Age);*/
            /*
            Person p2 = (Person)RPorm.SelectById(typeof(Dog), 1);
            if (p2 == null)
            {
                Console.WriteLine("没找到狗");
            }
            else
            {
                Console.WriteLine(p2.Name);
            }*/

            Dog d1 = RPorm.SelectById<Dog>(1);
            Console.WriteLine(d1.Name);
            d1.Weight++;
            RPorm.Update(d1);

            Console.ReadKey();
        }
    }
}
