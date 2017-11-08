using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanCeng.Model
{
    public class LogDTO
    {
        public long Id { set; get; }
        public string UserName { set; get; }
        public string UserPhoneNum { set; get; }
        public DateTime CreateDateTime { get; set; }
        public string Message { get; set; }
    }
}
