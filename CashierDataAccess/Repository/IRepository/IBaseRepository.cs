using CashierDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CashierDataAccess.Repository.IRepository
{
    public interface IBaseRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GitById(int id);
        Task<T> Get();
        Task Add(T entity);
        void Delete(int id);
        void Update(T entity);
        Task DeleteRange(IEnumerable<T> entities);
    }
}
