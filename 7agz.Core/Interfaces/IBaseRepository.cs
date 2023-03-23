using _7agz.Core.Consts;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _7agz.Core.Interfaces
{
    public interface IBaseRepository <T> where T : class
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        T Find(Expression<Func<T, bool>> criteria);
        T Find(Expression<Func<T, bool>> criteria, string[] includes);
        IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria);
        IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, string[] includes);
        IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, string[] includes, Expression<Func<T, object>> orderBy, string orderByDirection = OrderBy.Ascending);
        T GetHourDetails(Expression<Func<T, bool>> criteria);
        T Add(T entity);
        IEnumerable<T> AddRange(IEnumerable<T> entities);
        T Update(int id, JsonPatchDocument entity);
        T UpdateByPut(int id, T entity);
        void Delete(T entity);


    }
}
