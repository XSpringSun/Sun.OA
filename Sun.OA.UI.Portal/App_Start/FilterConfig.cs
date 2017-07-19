using Sun.OA.UI.Portal.Models;
using System.Web;
using System.Web.Mvc;

namespace Sun.OA.UI.Portal
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //过滤器：打上标签 进行验证  
            //ActionFilter ResultFilter 异常过滤器 IExceptionFilter
            //filters.Add(new HandleErrorAttribute());

            filters.Add(new MyExceptionFilterAttribute());

            //登录校验
            //filters.Add(new LoginCheckFilterAttribute() { IsCheck = true });
        }
    }
}