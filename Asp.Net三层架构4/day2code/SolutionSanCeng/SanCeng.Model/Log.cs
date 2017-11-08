using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanCeng.Model
{
    public class Log
    {
        public long Id { set; get; }
        public long UserId { get; set; }
        public DateTime CreateDateTime { get; set; }
        public string Message { get; set; }
    }
}
