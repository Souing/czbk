using SchoolDTO;
using SchoolService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolWeb.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            StudentService stuService = new StudentService();
            var students = stuService.GetByClassId(1);
            return View(students);
        }

        [HttpGet]
        public ActionResult AddNew()
        {
            MinZuService mzService = new MinZuService();
            var minzus = mzService.GetAll();

            //SelectList slMinZus = new SelectList(minzus,"Id","Name");
            SelectList slMinZus = new SelectList(minzus, 
                nameof(MinZuDTO.Id), nameof(MinZuDTO.Name));
            return View(slMinZus);
        }

        [HttpPost]
        public ActionResult AddNew(string name,int age,long minZuId)
        {
            StudentService ss = new StudentService();
            ss.AddNew(name, age, minZuId, 1);
            //return RedirectToAction("Index");

            //return RedirectToAction(nameof(Index));
            return Redirect("/Student/Index");
        }

        public ActionResult Delete(long id)
        {
            StudentService ss = new StudentService();
            ss.Delete(id);
            return Redirect("/Student/Index");
        }
    }
}