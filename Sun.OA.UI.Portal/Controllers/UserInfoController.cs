using Sun.OA.BLL;
using Sun.OA.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sun.OA.UI.Portal.Controllers
{
    public class UserInfoController : BaseController
    {
        //
        // GET: /UserInfo/

        IUserInfoService UserInfoService { get; set; }

        public ActionResult Index()
        {
            ViewData.Model = UserInfoService.GetEntities(u => true);
            return View();
        }

    }
}
