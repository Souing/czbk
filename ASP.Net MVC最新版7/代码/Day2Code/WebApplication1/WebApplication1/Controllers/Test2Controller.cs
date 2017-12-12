using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class Test2Controller : Controller
    {
        // GET: Test2
        public ActionResult Index()
        {
            Session["aa"] = "adfads";
            TempData["code"] = "1234";
            return View();
        }

        public ActionResult Hello()
        {
            return Content("Hello");
        }

        public ActionResult TempData1()
        {
            string code = (string)TempData["code"];
            return Content("code="+ code);
        }
    }
}