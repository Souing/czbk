﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFEntities
{
    public class Student:BaseEntity
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public long ClassId { get; set; }
        public Class Class { get; set;}
        public long MinZuId { get; set; }
        public MinZu MinZu { get; set; }
    }
}
