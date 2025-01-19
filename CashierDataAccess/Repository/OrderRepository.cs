using CashierDataAccess.Data;
using CashierDataAccess.Models;
using CashierDataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashierDataAccess.Repository
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        private AppDbContext _db;
        public OrderRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public override async Task<IEnumerable<Order>> GetAll()
        {
            return await _db.Orders.Include(o=>o.OrderDetails).ToListAsync();
        }

    }
}
