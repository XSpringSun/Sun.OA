using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sun.OA.IDAL
{
    public interface IBaseDal<T> where T : class,new()
    {
        //curd
        #region 查询

        IQueryable<T> GetEntities(Expression<Func<T, bool>> lambdaWhere);

        //分页
        IQueryable<T> GetPageEntities<TOrder>(int pageIndex, int pageSize, out int total,
                                                                       Expression<Func<T, bool>> whereLambda,
                                                                       Expression<Func<T, TOrder>> orderLambda,
                                                                       bool isAsc);

        #endregion

        #region cud

        T Add(T entity);

        bool Update(T entity);

        bool Delete(T entity);

        #endregion
    }
}
