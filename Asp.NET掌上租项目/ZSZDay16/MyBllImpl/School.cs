﻿using MyIBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBllImpl
{
    public class School : ISchool
    {
        public IDogBll DogBll { get; set; }

        public void FangXue()
        {
            DogBll.Bark();
            Console.WriteLine("放学啦");
        }
    }
}
