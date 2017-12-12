using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2
{
    public class QQNumberAttribute:RegularExpressionAttribute
    {
        public QQNumberAttribute():base(@"^\d{5,10}$")
        {
            this.ErrorMessage = "字段{0}不是合法的QQ号，QQ号长度在5-10位";
        }
    }
}