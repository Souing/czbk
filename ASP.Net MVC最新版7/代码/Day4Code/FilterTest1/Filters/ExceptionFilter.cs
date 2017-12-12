using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FilterTest1.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            string path = filterContext.HttpContext.Server.MapPath("~/err.txt");
            Exception ex = filterContext.Exception;
            File.AppendAllText(path, ex.ToString()+"\n");

        }
    }
}