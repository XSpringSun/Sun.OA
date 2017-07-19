using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sun.OA.UI.Portal.Models
{
    public class MyExceptionFilterAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
            //处理异常
            Common.LogHelper.WriteLog(filterContext.Exception.ToString());
        }
    }
}