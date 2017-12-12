using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentAPI1
{
    class Program
    {
        static void F(string sql)
        {

        }
        static void Main(string[] args)
        {
            using (MYContext ctx = new MYContext())
            {
                //ctx.Database.Log = F;
                ctx.Database.Log = (sql) => {
                    Console.WriteLine("*************Log**********"+sql);
                };
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
                /*
                var items = (from p in ctx.Persons
                             orderby p.Age
                             select p).Skip(1).Take(2);//.ToList();

                Console.WriteLine("准备开始foreach喽！！！！！！！！！");
                foreach (var p in items)
                {
                    Console.WriteLine(p);
                }*/
                /*
                Person p = ctx.Persons.First();
                p.Name = "rrr";
                p.Age = 666;
                ctx.SaveChanges();*/

                //long[] ids = { 2, 5, 6 };//不要写成int[]
                // var result = ctx.Persons.Where(p => ids.Contains(p.Id));

                //必须写成IQueryable<Person>，如果写成IEnumerable就会在内存中取后续数据
                /*
                IQueryable<Person> result = ctx.Persons.Where(p=>p.Id>3);
                result = result.Where(p=>p.Name.Length>3);

                result.ToList();*/
                /*
                string name = Console.ReadLine();
                int age = 888;
                ctx.Database.ExecuteSqlCommand("insert into T_Persons(Name,CreateDateTime,Age) values({0},GetDate(),{1})", name, age);*/
                /*
                var result =  ctx.Database.SqlQuery<GroupCount>("select age,count(*) AgeCount from T_Persons group by Age");
                foreach(GroupCount item in result)
                {
                    Console.WriteLine(item.Age+"="+item.AgeCount);
                }*/
                /*
                var result = ctx.Database.SqlQuery<Person>("select * from T_Persons");
                foreach(var p in result)
                {
                    Console.WriteLine(p);
                }*/
                /*
                var result = ctx.Database.SqlQuery<string>("select Name from T_Persons");
                foreach(string item in result)
                {
                    Console.WriteLine(item);
                }*/
                /*
                int i = ctx.Database.SqlQuery<int>("select count(*) from T_Persons").Single();
                Console.WriteLine(i);*/
                // var result = ctx.Persons.Where(p=>SqlFunctions.DateDiff("hour",p.CreateDateTime,DateTime.Now)>1);
                //var result = ctx.Persons.Where(p => (DateTime.Now - p.CreateDateTime).TotalHours > 1);
                //var result = ctx.Persons.Where(p => p.Id==3);
                //var result = ctx.Persons.Where(p => Convert.ToString(p.Id) == "3");
                //result.ToList();


                // Person p1 = ctx.Persons.SingleOrDefault(p => p.Id == 1);
                /*
                Person p1 = new Person() {Id=1,Age=666,CreateDateTime=DateTime.Parse("2017-03-14 16:38:25.417"),Name="rrr" };
                ctx.Persons.Remove(p1);
                //p1.Age++;
                ctx.SaveChanges();*/
                /*
                Person p1 = new Person() { Age=119,
                    CreateDateTime =DateTime.Now,Name="hj"};
                Console.WriteLine(ctx.Entry(p1).State);
                //ctx.Entry(p1).State = System.Data.Entity.EntityState.Added;
                ctx.Persons.Add(p1);
                Console.WriteLine(ctx.Entry(p1).State);

                ctx.SaveChanges();
                Console.WriteLine(ctx.Entry(p1).State);*/
                /*
                Person p1 = new Person { Id=1};
                Console.WriteLine(ctx.Entry(p1).State);
                ctx.Persons.Attach(p1);
                Console.WriteLine(ctx.Entry(p1).State);
                p1.Name = "rupeng.com";
                Console.WriteLine(ctx.Entry(p1).State);
                ctx.SaveChanges();
                Console.WriteLine(ctx.Entry(p1).State);*/

                /*
                Person p1 = ctx.Persons.First();
                Console.WriteLine(ctx.Entry(p1).State);
                p1.Age = 111;
                Console.WriteLine(ctx.Entry(p1).State);
                ctx.SaveChanges();
                Console.WriteLine(ctx.Entry(p1).State);
                */
                /*
                Person p1 = ctx.Persons.First();
                Console.WriteLine(ctx.Entry(p1).State);
                //ctx.Persons.Remove(p1);
                ctx.Entry(p1).State = System.Data.Entity.EntityState.Deleted;
                Console.WriteLine(ctx.Entry(p1).State);
                ctx.SaveChanges();
                Console.WriteLine(ctx.Entry(p1).State);

                //ctx.Persons.Add(p1);
                ctx.Entry(p1).State = System.Data.Entity.EntityState.Added;
                ctx.SaveChanges();
                Console.WriteLine(ctx.Entry(p1).State);
                */
                /*
                Person p1 = new Person();
                p1.Id = 6;
                p1.Name = "如鹏网";
                Console.WriteLine(ctx.Entry(p1).State);
                ctx.Persons.Attach(p1);
                Console.WriteLine(ctx.Entry(p1).State);
                ctx.Entry(p1).Property(e => e.Name).IsModified = true;
                Console.WriteLine(ctx.Entry(p1).State);
                ctx.SaveChanges();
                Console.WriteLine(ctx.Entry(p1).State);*/

                /*
                foreach(var p in ctx.Persons.AsNoTracking().Where(p=>p.Id>5))
                {
                   
                    p.Age++;
                    Console.WriteLine(p);
                }*/
                var p = ctx.Persons.AsNoTracking().First();
                Console.WriteLine(ctx.Entry(p).State);
                ctx.Entry(p).State = System.Data.Entity.EntityState.Unchanged;
                p.Name = "哈哈哈哈";
                Console.WriteLine(ctx.Entry(p).State);
                ctx.SaveChanges();

                Console.ReadKey();
            }
        }
    }
}
