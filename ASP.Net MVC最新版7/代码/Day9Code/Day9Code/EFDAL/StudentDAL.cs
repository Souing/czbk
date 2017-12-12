using EFDTO;
using EFEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EFDAL
{
    public class StudentDAL
    {
        //DTO保证了，返回的对象一定是普通的对象，而不是和EF关联的对象 
        //对DTO的任何操作也不会影响数据库，避免层之间的耦合 
        public StudentDTO GetById(long id)
        {
            using (MyContext ctx = new MyContext())
            {
               Student s = ctx.Students.AsNoTracking()
                    .Include(e=>e.MinZu).Include(e => e.Class).SingleOrDefault(e=>e.Id==id);
                StudentDTO dto = new StudentDTO();
                dto.Id = s.Id;
                dto.Age = s.Age;
                dto.Name = s.Name;
                dto.ClassName = s.Class.Name;
                dto.MinZuName = s.MinZu.Name;
                return dto;
            }
        }
    }
}
