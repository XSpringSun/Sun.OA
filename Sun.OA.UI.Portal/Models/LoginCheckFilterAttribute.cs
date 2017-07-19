using Sun.OA.Common.Cache;
using Sun.OA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Providers.Entities;

namespace Sun.OA.UI.Portal.Models
{
    public class LoginCheckFilterAttribute : ActionFilterAttribute
    {
        public bool IsCheck { get; set; }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            //校验用户是否已登录
            if (IsCheck)
            {
                //用cookie + memcache代替Session
                //var loginUser = filterContext.HttpContext.Session["LoginUser"];

                string userGuidCookie = filterContext.HttpContext.Request.Cookies["userLoginId"].Value;
                if (string.IsNullOrEmpty(userGuidCookie))
                {
                    filterContext.HttpContext.Response.Redirect("/UserLogin/Index");
                    return;
                }
                var loginUser = CacheHelper.GetCache(userGuidCookie);

                if (loginUser == null)
                {
                    //用户缓存过期
                    filterContext.HttpContext.Response.Redirect("/UserLogin/Index");
                    return;
                }

            }
        }
    }
}