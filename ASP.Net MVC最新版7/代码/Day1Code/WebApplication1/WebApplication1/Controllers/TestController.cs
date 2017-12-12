using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class TestController : Controller
    {
        public ActionResult Index(IndexModel model)
        {
            model.Result = model.Num1 + model.Num2;
            ViewData["myname"] = "yzk";
            ViewData["age"] = 18;
            ViewBag.name2 = "qq";
            ViewBag.gender = "男";
            return View(model);
        }

        public ActionResult F1()
        {
            Person p1 = new Person();
            p1.Age = 18;
            p1.Name = "yzk";
            return View(p1);
        }
    }

    public class Person {
         public int Age { get; set; }
        public string Name { get; set; }
    }
}