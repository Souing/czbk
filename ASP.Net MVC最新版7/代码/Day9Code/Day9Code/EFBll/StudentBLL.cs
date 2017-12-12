using EFDAL;
using EFDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFBll
{
    public class StudentBLL
    {
        public StudentDTO GetById(long id)
        {
            return new StudentDAL().GetById(id);
        }
    }
}
