using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IDataBaseAccess<T> where T : class
    {
        IList<T> GetAll();
        IList<T> GetByCondition(Object Condition, string ConditionName);
        IList<T> GetAllByOrder();
        IQueryable<T> Query();
        T GetById(int id);
        T LoadById(int id);
        int Save(T obj);
        void Update(T obj);
        void Delete(T obj);
        void Add(T obj);
    }
}
