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
        //彻底解耦 抽象工厂，用反射程序集创建对象
        public static string assemblyName = System.Configuration.ConfigurationManager.AppSettings["DalAssemblyName"];
        //public static IUserInfoDal GetUserInfoDal()
        //{
        //    //简单工厂方式
        //    //return new UserInfoDal();
        //    return Assembly.Load(assemblyName).CreateInstance(assemblyName + ".UserInfoDal") as IUserInfoDal;
        //}
    }
}
