using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FilterTest1.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(string username,
            string password)
        {
           // string s = null;
           // s.ToString();
            if(username=="a"&&password=="123")
            {
                Session["username"] = "a";
                return Content("登录成功");
            }
            else if (username == "b" && password == "123")
            {
                Session["username"] = "b";
                return Content("登录成功");
            }
            else
            {
                return Content("登陆失败");
            }
        }
    }
}