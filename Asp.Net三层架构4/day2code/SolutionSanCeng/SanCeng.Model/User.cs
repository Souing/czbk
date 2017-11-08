using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanCeng.Model
{
    public class User
    {
        public long Id { get; set; }
        public int? Age { get; set; }
        public string UserName { get; set; }
        public string PhoneNum { get; set; }
        public string Password { get; set; }
        public bool IsDeleted { get; set; }
    }
}
