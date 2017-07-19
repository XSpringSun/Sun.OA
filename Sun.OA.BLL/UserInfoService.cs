using Sun.OA.DALFactory;
using Sun.OA.EFDAL;
using Sun.OA.IBLL;
using Sun.OA.IDAL;
using Sun.OA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sun.OA.BLL
{
    //模块内高内聚，模块间低耦合

    //解决低耦合 首先想到Interface，依赖方法，不依赖实现
    public partial class UserInfoService : BaseService<UserInfo>, IUserInfoService
    {
        #region old


        //这种方式也产生了修改Dal实现的麻烦，所以产生工厂封装Dal创建
        //IUserInfoDal dal = new UserInfoDal();

        //这是抽象工厂，但是更高级的用法是：IOC DI 依赖注入  Spring.Net
        //IUserInfoDal dal = StaticDALFactory.GetUserInfoDal();

        //private IDbSession dbSession = DbSessionFactory.GetCurrentDbSession();

        //public UserInfo Add(UserInfo info)
        //{
        //    dbSession.UserInfoDal.Add(info);

        //    dbSession.SaveChanges();//数据提交的权利从数据库访问层提到了业务逻辑层

        //    return info;
        //}
        #endregion
        //public override void SetCurrentDal()
        //{
        //    currentDal = DbSession.UserInfoDal;
        //}

    }
}
