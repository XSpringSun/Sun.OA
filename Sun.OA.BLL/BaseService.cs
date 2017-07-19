using Sun.OA.DALFactory;
using Sun.OA.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sun.OA.BLL
{
    public abstract class BaseService<T> where T : class,new()
    {
        public IBaseDal<T> currentDal { get; set; }

        public IDbSession DbSession
        {
            get
            {
                return DbSessionFactory.GetCurrentDbSession();
            }
        }

        public BaseService()
        {
            SetCurrentDal();
        }

        public abstract void SetCurrentDal();


        #region 查询

        public IQueryable<T> GetEntities(Expression<Func<T, bool>> lambdaWhere)
        {
            return currentDal.GetEntities(lambdaWhere);
        }

        //分页
        public IQueryable<T> GetPageEntities<TOrder>(int pageIndex, int pageSize, out int total,
                                                                        Expression<Func<T, bool>> whereLambda,
                                                                        Expression<Func<T, TOrder>> orderLambda,
                                                                        bool isAsc)
        {
            return currentDal.GetPageEntities<TOrder>(pageIndex, pageSize, out total, whereLambda, orderLambda, isAsc);
        }

        #endregion

        #region cud

        public T Add(T entity)
        {
            currentDal.Add(entity);
            DbSession.SaveChanges();
            return entity;
        }

        public bool Update(T entity)
        {
            currentDal.Update(entity);
            return DbSession.SaveChanges() > 0;
        }

        public bool Delete(T entity)
        {
            currentDal.Delete(entity);
            return DbSession.SaveChanges() > 0;
        }
        #endregion
    }
}
