using EFBll;
using EFDTO;
using EFEntities;
using MVCTest1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCTest1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            using (MyContext ctx = new MyContext())
            {
                /*
                MinZu mz = new MinZu { Name="汉族"};
                ctx.MinZus.Add(mz);
                ctx.SaveChanges();*/
                var clz = ctx.Classes.First();
                var students = ctx.Students.Where(s => s.ClassId == clz.Id).ToList();
                //ViewBag.students = students;
                HomeIndexModel hiModel = new HomeIndexModel();
                hiModel.Class = clz;
                hiModel.Students = students;
                return View(hiModel);
            }            
        }

        public ActionResult Index2()
        {
            StudentBLL bll = new StudentBLL();
            StudentDTO s = bll.GetById(1);
            return View(s);
        }
    }
}