using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2
{
    public static class MVCHelper
    {
        public static string GetValidMsg(ModelStateDictionary modelState)
        {
           
            StringBuilder sb = new StringBuilder();
            //遍历每个属性
            foreach(var propName in modelState.Keys)
            {
                //modelState[propName].Errors是属性相关的错误消息
                if (modelState[propName].Errors.Count<=0)
                {
                    continue;
                }
                sb.Append("属性错误：").Append(propName).Append(":");
                //遍历每个错误消息（因为一个属性可能有多个错误消息）
                foreach(ModelError modelError in modelState[propName].Errors)
                {
                    sb.Append(modelError.ErrorMessage);
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}