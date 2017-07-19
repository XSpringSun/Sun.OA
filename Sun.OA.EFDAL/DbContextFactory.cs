using Sun.OA.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Sun.OA.EFDAL
{
    public class DbContextFactory
    {
        public static DbContext GetCurrentDbContext()
        {
            //一个请求共用一个上下文实例，
            //return new DataModelContainer();
            DbContext db = CallContext.GetData("DbContext") as DbContext;
            if (db == null)
            {
                db = new DataModelContainer();
                CallContext.SetData("DbContext", db);
            }
            return db;
        }
    }
}
