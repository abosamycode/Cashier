using CashierDataAccess.Data;
using CashierDataAccess.Models;
using CashierDataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CashierDataAccess.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly AppDbContext _db;
        internal DbSet<T> _dbSet;

        public BaseRepository(AppDbContext db)
        {
            _db = db;
            this._dbSet = _db.Set<T>();
        }

        public async Task Add(T entity)
        {
          await  _dbSet.AddAsync(entity);
        }

        public  async void Delete(int id )
        {
            var entity = await GitById(id);
            _dbSet.Remove(entity);
        }

        public Task DeleteRange(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public Task<T> Get()
        {
            throw new NotImplementedException();
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GitById(int id)
        {
          return  await  _dbSet.FindAsync(id);
        }
        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }



    }
}
