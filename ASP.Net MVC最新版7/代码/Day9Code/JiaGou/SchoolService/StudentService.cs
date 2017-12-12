using EFEntities;
using SchoolDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace SchoolService
{
    public class StudentService
    {
        public void AddNew(string name,int age,
            long minzuId,long classId)
        {
            using (MyContext ctx = new MyContext())
            {
                Student s = new Student();
                s.Age = age;
                s.ClassId = classId;
                s.MinZuId = minzuId;
                s.Name = name;
                ctx.Students.Add(s);
                ctx.SaveChanges();
            }
        }

        public void Delete(long id)
        {
            using (MyContext ctx = new MyContext())
            {
                /*
                var stu = ctx.Students.SingleOrDefault(s=>s.Id==id);
                if(stu==null)
                {
                    throw new ArgumentException("没找到id="+id+"的学生");
                }
                ctx.Students.Remove(stu);*/
                var stu = new Student();
                stu.Id = id;
                ctx.Entry(stu).State 
                    = System.Data.Entity.EntityState.Deleted;
                ctx.SaveChanges();
            }
        }

        public StudentDTO GetById(long id)
        {
            using (MyContext ctx = new MyContext())
            {
                var s = ctx.Students.AsNoTracking().Include(e=>e.MinZu)
                    .Include(e => e.Class).SingleOrDefault(e=>e.Id==id);
                if(s==null)
                {
                    return null;
                }
                /*
                StudentDTO dto = new StudentDTO();
                dto.Age = s.Age;
                dto.ClassId = s.ClassId;
                dto.ClassName = s.Class.Name;
                dto.Id = s.Id;
                dto.MinZuId = s.MinZuId;
                dto.MinZuName = s.MinZu.Name;
                dto.Name = s.Name;
                return dto;*/
                return ToDTO(s);
            }
        }

        private StudentDTO ToDTO(Student s)
        {
            //AutoMapper  EF DB Migration
            StudentDTO dto = new StudentDTO();
            dto.Age = s.Age;
            dto.ClassId = s.ClassId;
            dto.ClassName = s.Class.Name;
            dto.Id = s.Id;
            dto.MinZuId = s.MinZuId;
            dto.MinZuName = s.MinZu.Name;
            dto.Name = s.Name;
            return dto;
        }

        public IEnumerable<StudentDTO> GetByClassId(long classId)
        {
            using (MyContext ctx = new MyContext())
            {
                var students = ctx.Students.AsNoTracking().Include(e => e.MinZu)
                    .Include(e => e.Class).Where(e => e.ClassId==classId);
                List<StudentDTO> list = new List<StudentDTO>();//yield
                foreach (var s in students)
                {
                    /*
                    StudentDTO dto = new StudentDTO();
                    dto.Age = s.Age;
                    dto.ClassId = s.ClassId;
                    dto.ClassName = s.Class.Name;
                    dto.Id = s.Id;
                    dto.MinZuId = s.MinZuId;
                    dto.MinZuName = s.MinZu.Name;
                    dto.Name = s.Name;
                    list.Add(dto);*/
                    list.Add(ToDTO(s));
                }
                return list;
            }
        }
    }
}
