using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            //重定向到和在同一个Controller的F1这个Action下
            // return RedirectToAction("List", "Person");// Redirect("/Person/List")
            //return RedirectToAction("F1");
            //return Redirect("/Test/F1");
            //return View();

            //return RedirectToAction("F1");
            //return View("F1");

            //
            ViewBag.Name = "rupeng";
            // return View("F1");
            //return RedirectToAction("F1");
            return View("F2");//直接让F2.cshtml显示。F2()方法不会执行

            //return RedirectToAction("F2");// /Test/F2
            //是让浏览器重定向到/Test/F2 是，所以F2()方法会执行
        }

        public ActionResult F2()
        {
            return View();
        }

        public ActionResult F1()
        {
            //return View("F2");
            return View();
        }
    }
}