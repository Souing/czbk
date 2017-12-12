using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class Val1Controller : Controller
    {
        // GET: Val1
        public ActionResult Index(IndexModel model)
        {
            //参数校验是否通过
            if(ModelState.IsValid)
            {
                return Content("Age=" + model.Age);
            }
            else
            {
                string msg = MVCHelper.GetValidMsg(ModelState);
                return Content("验证失败"+msg);
            }
           
        }
    }
}