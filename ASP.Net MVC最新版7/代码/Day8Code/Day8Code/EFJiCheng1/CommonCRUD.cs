using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EFJiCheng1
{
    class CommonCRUD<T> where T: BaseEntity
        //T是泛型，T必须是继承自BaseEntity的类
    {
        private MyContext ctx;
        public CommonCRUD(MyContext ctx)
        {
            this.ctx = ctx;
        }

        public void MarkDeleted(long id)
        {
            //ctx.Persons  ==    ctx.Set<Person>()
           T item = ctx.Set<T>().Where(e=>e.Id==id).SingleOrDefault();
            if(item==null)
            {
                throw new ArgumentException("找不到id="+id+"的数据");
            }
            item.IsDeleted = true;
            item.DeleteDateTime = DateTime.Now;
            ctx.SaveChanges();
        }

        public T GetById(long id)
        {
            T item = ctx.Set<T>().Where(e => e.Id == id && e.IsDeleted == false)
                .SingleOrDefault();
            return item;
        }

        public IQueryable<T> GetAll(int start,int count)
        {
            return ctx.Set<T>().OrderBy(e=>e.CreateDateTime)
                .Skip(start).Take(count).Where(e=>e.IsDeleted==false);
        }

        public long GetTotalCount()
        {
            return ctx.Set<T>().Where(e => e.IsDeleted == false).LongCount();
        }
    }
}
