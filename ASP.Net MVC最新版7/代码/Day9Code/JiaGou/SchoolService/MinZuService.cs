using EFEntities;
using SchoolDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolService
{
    public class MinZuService
    {
        //返回值的类型尽可能的“小”（足够的类型）
        public IEnumerable<MinZuDTO> GetAll()
        {
            using (MyContext ctx = new MyContext())
            {
                List<MinZuDTO> list = new List<MinZuDTO>();
                foreach(var mz in ctx.MinZus)
                {
                    var dto = new MinZuDTO();
                    dto.Id = mz.Id;
                    dto.Name = mz.Name;
                    list.Add(dto);
                }
                return list;
            }
        }
    }
}
