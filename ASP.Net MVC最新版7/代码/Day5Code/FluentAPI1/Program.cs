using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentAPI1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (MYContext ctx = new MYContext())
            {
                /*
                Person p1 = new Person();
                p1.Age = 18;
                p1.CreateDateTime = DateTime.Now;
                p1.Name = "EF";
                ctx.Persons.Add(p1);*/

                /*
                Dog d = new Dog();
                d.Name = "旺财";
                //ctx.Dogs.Add(d);
                ctx.Set<Dog>().Add(d);
                Console.WriteLine("Id="+d.Id);
                ctx.SaveChanges();
                Console.WriteLine("Id=" + d.Id);*/
                // IQueryable<Person> persons = ctx.Persons.Where(p=>p.Age>10);
                //var persons = ctx.Persons.Where(p=>p.Age>10);
                /*
                var persons = from p in ctx.Persons
                              where p.Age > 10
                              select p;
                foreach(var p in persons)
                {
                    Console.WriteLine(p);
                }*/

                //var person = ctx.Persons.Where(p => p.Id == 4).SingleOrDefault();

                /*
                var person = ctx.Persons.SingleOrDefault(p=>p.Id==4);
                if(person==null)
                {
                    Console.WriteLine("已被删除");
                }
                else
                {
                    ctx.Persons.Remove(person);
                    ctx.SaveChanges();
                }*/
                /*
                ctx.Persons.RemoveRange(ctx.Persons.Where(p => p.Age > 10));
                ctx.SaveChanges();*/
                /*
                var persons =  ctx.Persons;
                foreach(var p in persons)
                {
                    p.Age++;
                }
                ctx.SaveChanges();*/
                /*
                var items = from p in ctx.Persons
                            group p by p.Age into g1
                            select new { Age = g1.Key, Count = g1.Count(), IdMax = g1.Max(p => p.Id) };
                foreach(var item in items)
                {
                    Console.WriteLine(item.Age+"="+item.Count+","+item.IdMax);
                }*/
                /*
                var items = from p in ctx.Persons
                            orderby p.Age
                            select p;
                foreach(var p in items)
                {
                    Console.WriteLine(p);
                }*/
                // var items = ctx.Persons.OrderBy(p=>p.Age).Skip(1).Take(2);
                var items = (from p in ctx.Persons
                             orderby p.Age
                             select p).Skip(1).Take(2);
                foreach (var p in items)
                {
                    Console.WriteLine(p);
                }
                Console.ReadKey();
            }
        }
    }
}
