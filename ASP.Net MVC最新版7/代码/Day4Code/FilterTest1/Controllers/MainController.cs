using FilterTest1.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FilterTest1.Controllers
{
    [Log2ActionFilter]
    public class MainController : Controller
    {       
        public ActionResult Index()
        {
            return Content("Index出来喽！！！" + Session["username"]);
        }

        public ActionResult ZZ()
        {
            return Content("开始转账！！！" + Session["username"]);
        }
    }
}