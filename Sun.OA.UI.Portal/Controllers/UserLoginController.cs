using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sun.OA.IBLL;
using Sun.OA.UI.Portal.Models;
using Sun.OA.Common.Cache;

namespace Sun.OA.UI.Portal.Controllers
{
    public class UserLoginController : BaseController
    {
        public UserLoginController()
        {
            IsCheck = false;
        }

        public IUserInfoService UserInfoService { get; set; }

        public ActionResult Index()
        {
            return View();
        }


        #region 验证码
        public ActionResult ShowCode()
        {
            Common.ValidateCode validateCode = new Common.ValidateCode();
            string code = validateCode.CreateValidateCode(4);
            Session["VCode"] = code;
            byte[] imgByte = validateCode.CreateValidateGraphic(code);
            return File(imgByte, @"image/jpeg");
        }
        #endregion

        public ActionResult ProcessLogin()
        {
            //1、处理验证码
            if (Session["VCode"] == null)
            {
                return Content("验证码错误！");
            }
            string vCode = Request["vCode"];
            string sessionCode = Session["VCode"].ToString();
            Session["VCode"] = null;
            if (string.IsNullOrEmpty(sessionCode) || vCode != sessionCode)
            {
                return Content("验证码错误！");
            }
            //2、验证用户名密码
            string uName = Request["uName"] as string;
            string uPassword = Request["uPassword"] as string;
            short delFlag = (short)Sun.OA.Model.Enum.DelFlagEnum.Normal;
            var userInfo = UserInfoService.GetEntities(u => u.UName == uName && u.UPwd == uPassword && u.DelFlag == delFlag).FirstOrDefault();
            if (userInfo == null)
            {
                return Content("登录错误，用户名或密码错误！");
            }

            //3、验证正确 跳转到首页
            //memcache分布式缓存代替session
            //Session["LoginUser"] = userInfo;
            string userLoginId = Guid.NewGuid().ToString();
            CacheHelper.AddCache(userLoginId, userInfo, DateTime.Now.AddMinutes(20));
            //往客户端写入cookie
            Response.Cookies["userLoginId"].Value = userLoginId;
            return Content("ok");
        }

    }
}
