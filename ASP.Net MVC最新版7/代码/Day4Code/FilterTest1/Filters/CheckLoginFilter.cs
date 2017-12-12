using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FilterTest1.Filters
{
    public class CheckLoginFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            //当前执行的Controller的名字
            string ctrlName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            //当前执行的Action的名字
            string actionName = filterContext.ActionDescriptor.ActionName;
            if (ctrlName=="Login"&&(actionName=="Index"||actionName=="Login"))
            {
                //什么都不做
            }
            else//检查登录状态
            {
                if(filterContext.HttpContext.Session["username"]==null)
                {
                    /*
                    ContentResult contentResult = new ContentResult();
                    contentResult.Content = "没有登录";

                    //如果在Filter中给filterContext.Result 赋值了，那么将不再继续执行要执行的Filter
                    //而是把filterContext.Result 执行，返回给用户
                    filterContext.Result = contentResult;
                    //阻止Action执行的*/
                    // filterContext.HttpContext.Response.Redirect("/Login/Index");
                    filterContext.Result = new RedirectResult("/Login/Index");
                }
            }
        }
    }
}