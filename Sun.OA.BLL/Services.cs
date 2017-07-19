
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
  
	public partial class UserInfoService : BaseService<UserInfo>, IUserInfoService
	{
	    public override void SetCurrentDal()
        {
            currentDal = DbSession.UserInfoDal;
        }
	}
}
    