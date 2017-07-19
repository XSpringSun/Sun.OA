using Sun.OA.Common.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sun.OA.Model;

namespace Sun.OA.UI.Portal.Controllers
{
    public class BaseController : Controller
    {
        /// <summary>
        /// 是否验证已经登录
        /// </summary>
        //ToDo:项目完成后设置成true
        public bool IsCheck = false;

        public UserInfo LoginUser { get; set; }
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            //校验用户是否已登录
            if (IsCheck)
            {
                //用cookie + memcache代替Session
                //var loginUser = filterContext.HttpContext.Session["LoginUser"];


                if (Request.Cookies["userLoginId"] == null)
                {
                    Response.Redirect("/UserLogin/Index");
                    return;
                }
                string userGuidCookie = Request.Cookies["userLoginId"].Value;
                var loginUser = CacheHelper.GetCache(userGuidCookie);

                if (loginUser == null)
                {
                    //用户缓存过期
                    Response.Redirect("/UserLogin/Index");
                    return;
                }

                LoginUser = loginUser as UserInfo;
                //滑动窗口，缓存时间
                CacheHelper.SetCache(userGuidCookie, loginUser, DateTime.Now.AddMinutes(20));

            }
        }

    }
}