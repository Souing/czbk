using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Person
    {
        public long Id{get;set;}
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime CreateDate { get; set; }
    }
}