using Sun.OA.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sun.OA.EFDAL
{
    /// <summary>
    /// 职责：封装Dal公共的方法
    /// </summary>
    public class BaseDal<T> where T : class,new()
    {
        public DbContext Db
        {
            get
            {
                return DbContextFactory.GetCurrentDbContext();
            }
        }
        //curd
        #region 查询

        public IQueryable<T> GetEntities(Expression<Func<T, bool>> lambdaWhere)
        {
            return Db.Set<T>().Where(lambdaWhere).AsQueryable();
        }

        //分页
        public IQueryable<T> GetPageEntities<TOrder>(int pageIndex, int pageSize, out int total,
                                                                        Expression<Func<T, bool>> whereLambda,
                                                                        Expression<Func<T, TOrder>> orderLambda,
                                                                        bool isAsc)
        {
            total = Db.Set<T>().Where(whereLambda).Count();

            if (isAsc)
            {
                var temp = Db.Set<T>().Where(whereLambda)
                    .OrderBy(orderLambda)
                    .Skip(pageIndex * (pageSize - 1))
                    .Take(pageSize).AsQueryable();

                return temp;
            }
            else
            {
                var temp = Db.Set<T>().Where(whereLambda)
                    .OrderByDescending(orderLambda)
                    .Skip(pageIndex * (pageSize - 1))
                    .Take(pageSize).AsQueryable();

                return temp;
            }
        }

        #endregion

        #region cud

        public T Add(T entity)
        {
            Db.Set<T>().Add(entity);
            //Db.SaveChanges();
            return entity;
        }

        public bool Update(T entity)
        {
            Db.Entry(entity).State = EntityState.Modified;
            //return Db.SaveChanges() > 0;
            return true;
        }

        public bool Delete(T entity)
        {
            Db.Entry(entity).State = EntityState.Deleted;
            //return Db.SaveChanges() > 0;
            return true;
        }
        #endregion
    }
}
