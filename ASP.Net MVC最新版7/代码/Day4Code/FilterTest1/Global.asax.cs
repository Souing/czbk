using FilterTest1.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FilterTest1
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            GlobalFilters.Filters.Add(new CheckLoginFilter());
            GlobalFilters.Filters.Add(new LogActionFilter());
            GlobalFilters.Filters.Add(new ExceptionFilter());
        }
    }
}
