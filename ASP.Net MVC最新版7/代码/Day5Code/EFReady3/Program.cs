using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFReady3
{
    class Program
    {
        static void Main(string[] args)
        {
            Master m1 = new Master { Id = 1, Name = "杨中科" };
            Master m2 = new Master { Id = 2, Name = "比尔盖茨" };
            Master m3 = new Master { Id = 3, Name = "周星驰" };
            Master[] masters = { m1, m2, m3 };

            Dog d1 = new Dog { Id = 1, MasterId = 3, Name = "旺财",Age=3 };
            Dog d2 = new Dog { Id = 2, MasterId = 3, Name = "汪汪", Age = 5 };
            Dog d3 = new Dog { Id = 3, MasterId = 1, Name = "京巴", Age = 3 };
            Dog d4 = new Dog { Id = 4, MasterId = 2, Name = "泰迪", Age = 2 };
            Dog d5 = new Dog { Id = 5, MasterId = 1, Name = "中华田园", Age = 2 };
            Dog[] dogs = { d1, d2, d3, d4, d5 };

            /*
            var items = dogs.Where(d => d.Id >= 1).Join(masters, d => d.MasterId, m => m.Id,
                (d, m) => new { DogName=d.Name,MasterName=m.Name});
            foreach(var item in items)
            {
                Console.WriteLine(item.DogName+","+item.MasterName);
            }*/
            //var items = dogs.Where(d=>d.Id>1);
            /*
            var items = from d in dogs
                        where d.Id>1
                        select d;


            foreach(var item in items)
            {
                Console.WriteLine(item);
            }*/

            /*
            var items = dogs.Where(d => d.Id > 1).Select(d=>
                new {DogName=d.Name,DId=d.Id});*/
            /*
        var items = from d in dogs
                    where d.Id>1
                    select new { DogName = d.Name, DId = d.Id };
        */
            /*
                foreach (var item in items)
                {
                    Console.WriteLine(item.DogName+","+item.DId);
                }

                IEnumerable<long> items2 = from d in dogs
                             select d.Id;
                foreach(long item2 in items2)
                {
                    Console.WriteLine(item2);
                }*/
            /*
        var items = from d in dogs
                    select new {HAhaName= d.Name, Id = d.Id,
                        Desc = "haha", Yes = d.Name + d.Id };*/

            /*
            var items = from d in dogs
                        //orderby d.Age
                        //orderby d.Age descending
                        orderby d.Age,d.MasterId descending
                        select d;
            foreach(var item in items)
            {
                Console.WriteLine(item);
            }*/
            /*
            var items = from d in dogs
                        join m in masters on d.MasterId equals m.Id
                        select new { DogName = d.Name, MasterName = m.Name };
            foreach(var item in items)
            {
                Console.WriteLine(item);
            }*/

            var items = from d in dogs
                        group d by d.Age into g
                        select new { g.Key, MaxId = g.Max(d => d.Id) };
            foreach(var item in items)
            {
                Console.WriteLine(item.Key+","+item.MaxId);
            }

            int[] nums = { 1, 3, 5, 8, 98, 2, 7, 102,93 };
            /*
            var nums2 = from n in nums
                        where n % 2 == 0
                        select n;
            int m = nums2.Max();
            Console.WriteLine(m);*/
            int m = (from n in nums
                     where n % 2 == 0
                     select n).Max();
            Console.WriteLine(m);

            Console.ReadKey();
        }
    }

    class Master
    {
        public long Id { get; set; }
        
        public string Name { get; set; }

        public override string ToString()
        {
            return "Id=" + Id + ",Name="+Name;
        }
    }
    class Dog
    {
        public long Id { get; set; }
        public long MasterId { get; set; }
        public int Age { set; get; }
        public string Name { get; set; }

        public override string ToString()
        {
            return "Id="+Id+",MasterId="+MasterId+",Name="+Name+",Age="+Age;
        }
    }


}
