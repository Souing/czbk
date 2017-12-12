using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class PersonController : Controller
    {
        public ActionResult List()
        {
            DataTable dt = 
                SqlHelper.ExecuteQuery("select * from T_Persons");
            return View(dt);
        }

        [HttpGet]
        public ActionResult Add()
        {
            //return new ViewResult() {};
             return View();
            //return RedirectToAction("Add");
        }

        [HttpPost]
        public ActionResult Add(string name,int age)
        {
            SqlHelper.ExecuteNonQuery("Insert into T_Persons(Name,Age) values(@Name,@Age)",
                new SqlParameter("@Name",name),
                 new SqlParameter("@Age", age));
            // return Content("afsadfsadf");
            return Redirect("/Person/List");
            //return View("List");
        }

        [HttpGet]
        public ActionResult Edit(long id)
        {
            DataTable dt =SqlHelper.ExecuteQuery("select * from T_Persons where Id=@Id",
                new SqlParameter("@Id", id));
            DataRow row = dt.Rows[0];
            Person model = new Person();
            model.Age = Convert.ToInt32(row["Age"]);
            model.Id = Convert.ToInt64(row["Id"]);
            model.Name = Convert.ToString(row["Name"]);
            return View(model);
        }

        [HttpPost]
        //public ActionResult Edit(long id,string name,int age)
        public ActionResult Edit(Person model)
        {
            SqlHelper.ExecuteNonQuery("Update T_Persons set Name=@Name,Age=@Age where Id=@Id",
                new SqlParameter("@Name",model.Name),
                new SqlParameter("@Age", model.Age),
                new SqlParameter("@Id", model.Id));
            return Redirect("/Person/List");
        }

        public ActionResult Delete(long id)
        {
            SqlHelper.ExecuteNonQuery("Delete from T_Persons where Id=@Id",
                 new SqlParameter("@Id", id));
            return Redirect("/Person/List");
        }
    }
}