
using Sun.OA.EFDAL;
using Sun.OA.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sun.OA.DALFactory
{
    public partial class StaticDALFactory
    {
      
	   public static IUserInfoDal GetUserInfoDal() 
	   {
		  return Assembly.Load(assemblyName).CreateInstance(assemblyName + ".UserInfoDal") as IUserInfoDal;
	   }
    }
}