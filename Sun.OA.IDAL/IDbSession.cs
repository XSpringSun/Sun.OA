
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sun.OA.IDAL
{
    public interface IDbSession
    {
      
	    IUserInfoDal UserInfoDal {get;}
    	int SaveChanges();
    }
}