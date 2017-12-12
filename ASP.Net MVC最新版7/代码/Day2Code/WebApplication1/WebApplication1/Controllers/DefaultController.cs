using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class DefaultController : Controller
    {
        public ActionResult J1()
        {
            return View();
        }

        public ActionResult JsonTest1()
        {
            Child c = new Child();
            c.BirthDay = DateTime.Now;
            c.Name = "tom";

            Parent father = new Parent();
            father.Name = "tidy";

            father.Child = c;
            c.Father = father;


            Person p1 = new Person();
            p1.Id = 333;
            p1.Name = "如鹏网";
            p1.Age = 18;
            p1.CreateDate = DateTime.Now;
            //JavaScriptSerilizer
            //return Json(p1);
            return Json(c);
            //return Json(p1,JsonRequestBehavior.AllowGet);
        }

        public ActionResult AR2()
        {
            return JavaScript("alert('aaa');");
            //return HttpNotFound();
        }

        public ActionResult AR1()
        {
            byte[] bytes = { 32,3,55,4,65};
           // System.IO.File
           // using (Stream stream = System.IO.File.OpenRead(@"C:\temp\1.jpg"))
            {
                //return File(bytes,"appliction/oct-stream");
                //return File(stream, "appliction/oct-stream","2.jpg");
                //Content-Disposition
                //不需要手动using（Dispose）
                Stream stream = System.IO.File.OpenRead(@"C:\temp\1.jpg");
                return File(stream, "image/jpeg", "2.jpg");
            }
                
        }

        [HttpGet]
        public ActionResult BaoMing()
        {
            //return View(model);
            //return View();
            //return View("F2Show");//找F2Show.cshtml显示
            IndexModel m = new IndexModel();
            m.Name = "rupeng.com";
            string s = "qq.com";
            //return View("AAA", s);
            return View("AAA",(object)s);//第二个参数就是model
        }

        [HttpPost]
        public ActionResult BaoMing(string name,string phoneNum,
            HttpPostedFileBase f1)
        {
            f1.SaveAs(Server.MapPath("~/" + f1.FileName));
            return Content("报名成功"+name);
        }


        [HttpGet]
        public ActionResult F3()
        {
            return Content("111");
        }

        [HttpPost]
        public ActionResult F3(string name)
        {
            return Content("名字"+name);
        }

        public ActionResult Index(IndexModel m,string gender)
        {
            return Content(m.Id+m.Name+gender);
           // return View();
        }

        public ActionResult F1(int? age, string name = "rupeng")
        {
            return Content("name="+name+",age="+age);
        }

        public ActionResult F2Show()
        {
            return View();
        }

        public ActionResult F2(FormCollection fc)
        {
            string name = fc["name"];
            string age = fc["age"];
            return Content("name="+name+",age="+age);
        }
    }

    public class Parent
    {
        public string Name { get; set; }
        public Child Child { get; set; }
    }
    public class Child
    {
        public DateTime BirthDay { get; set; }
        public string Name { get; set; }
        public Parent Father { get; set; }
    }

}