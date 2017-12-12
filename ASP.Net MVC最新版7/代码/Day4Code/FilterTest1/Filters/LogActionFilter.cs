using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FilterTest1.Filters
{
    public class LogActionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            string actionName = filterContext.ActionDescriptor.ActionName;
            string ctrlName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;

            string path = filterContext.HttpContext.Server.MapPath("~/log.txt");
            File.AppendAllText(path, "执行了" + ctrlName + "." + actionName);
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string actionName = filterContext.ActionDescriptor.ActionName;
            string ctrlName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            
            string path = filterContext.HttpContext.Server.MapPath("~/log.txt");
            File.AppendAllText(path,"将要执行"+ctrlName+"."+actionName);
            // filterContext.Result = 也可以通过给filterContext.Result赋值阻止Action的执行
        }
    }
}