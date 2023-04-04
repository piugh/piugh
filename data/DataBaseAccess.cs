using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DataBaseAccess<T> : IDataBaseAccess<T> where T : class
    {
        protected ISession Session;

        public DataBaseAccess()
        {
            Session = NHibernateHelper.GetSession();
        }

        #region 获取数据
        public IList<T> GetAll()
        {
            IList<T> list = Session.CreateCriteria<T>().List<T>();
            return list;
        }

        public IList<T> GetByCondition(Object Condition, string ConditionName)
        {
            IList<T> list = Session.CreateCriteria<T>()
                .Add(Restrictions.Eq(ConditionName, Condition)).List<T>();

            return list;
        }

        public IList<T> GetByCondition(Object Condition1, string Condition1Name, Object Condition2, string Condition2Name)
        {
            var tmp = Session.CreateCriteria(typeof(T))
                .Add(Restrictions.Eq(Condition1Name, Condition1))
                .Add(Restrictions.Eq(Condition2Name, Condition2))
                .List<T>();

            return tmp;
        }

        public IList<T> GetAllByOrder()
        {
            var tmp = Session.CreateCriteria(typeof(T))
                .AddOrder(new NHibernate.Criterion.Order("Order", true))
                .List<T>();

            return tmp;
        }

        public virtual IQueryable<T> Query()
        {
            var result = Session.Query<T>();
            return result;
        }

        public T GetById(int id)
        {
            T obj = Session.Get<T>(id);
            return obj;
        }

        public T LoadById(int id)
        {
            T obj = Session.Load<T>(id);
            return obj;
        }
        #endregion

        #region 修改数据
        public int Save(T obj)
        {
            var identifier = Session.Save(obj);
            Session.Flush();
            return Convert.ToInt32(identifier);
        }

        public void Update(T obj)
        {
            Session.SaveOrUpdate(obj);
            Session.Flush();
        }

        public void Add(T obj)
        {
            Session.Save(obj);
            Session.Flush();
        }

        public void Delete(string table, object obj)
        {
            Session.Delete(table, obj);
            Session.Flush();
        }

        public void DeleteT(T entity)
        {
            Session.Delete(entity);
            Session.Flush();
        }
        #endregion
    }

}
