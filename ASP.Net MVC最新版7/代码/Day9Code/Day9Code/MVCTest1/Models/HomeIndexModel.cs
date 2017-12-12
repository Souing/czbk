using EFEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCTest1.Models
{
    public class HomeIndexModel
    {
        public Class Class { get; set; }
        public IEnumerable<Student> Students { get; set; }
    }
}