using Sun.OA.EFDAL;
using Sun.OA.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sun.OA.DALFactory
{
    //部分类，防止T4模板生成的时候覆盖
    public partial class DbSession : IDbSession
    {
        //public IUserInfoDal UserInfoDal
        //{
        //    get
        //    {
        //        return StaticDALFactory.GetUserInfoDal();
        //    }
        //}


        public int SaveChanges()
        {
            return DbContextFactory.GetCurrentDbContext().SaveChanges();
        }

    }
}
