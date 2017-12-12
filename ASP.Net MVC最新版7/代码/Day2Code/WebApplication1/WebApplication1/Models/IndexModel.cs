using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class IndexModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public HttpPostedFileBase f1 { get; set; }
    }
}