using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            List<Person> list = new List<Person>();
            list.Add(new Person { Id=1,Name="rupeng",Age=18});
            list.Add(new Person { Id = 2, Name = "qq", Age = 10 });
            list.Add(new Person { Id = 3, Name = "baidu", Age = 80 });
            return View(list);
        }

        public ActionResult DDL1()
        {
            List<Person> list = new List<Person>();
            list.Add(new Person { Id = 1, Name = "rupeng", Age = 18 });
            list.Add(new Person { Id = 2, Name = "qq", Age = 10 });
            list.Add(new Person { Id = 3, Name = "baidu", Age = 80 });

            
            List<SelectListItem> sliList = new List<SelectListItem>();
            foreach(var p in list)
            {
                SelectListItem listItem = new SelectListItem();
                listItem.Selected = (p.Id == 2);
                listItem.Text = p.Name+"("+p.Age+")";
                listItem.Value = p.Id.ToString();
                sliList.Add(listItem);
            }
            //ViewBag.pid = 5;
            return View(sliList);
            /*
            var sList = from item in list
                        select new SelectListItem { Selected=item.Id==2,
                            Text =item.Name,Value=item.Id.ToString()};
            return View(sList);*/
        }


        public ActionResult DDL2()
        {
            List<Person> list = new List<Person>();
            list.Add(new Person { Id = 1, Name = "rupeng", Age = 18 });
            list.Add(new Person { Id = 12, Name = "qq", Age = 10 });
            list.Add(new Person { Id = 3, Name = "baidu", Age = 80 });

            SelectList selList = new SelectList(list,"Id","Name",12);
            ViewBag.selList = selList;
            return View();
        }

        public ActionResult Ajax1()
        {
            
            return View();
        }

        public ActionResult Ajax2()
        {
            Person p = new Person();
            p.Name = "rupeng";
            //主流浏览器在发出ajax请求的时候都会带着
            //X -Requested-With:XMLHttpRequest报文头
            
            if (Request.IsAjaxRequest())
            {
                return Json(p);
            }
            else
            {
                return Content(p.Name);
            }
            //return Content(p.Name);
        }
    }
}