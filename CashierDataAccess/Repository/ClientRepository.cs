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
    public class ClientRepository : BaseRepository<Client>, IClientRepository
    {
        private AppDbContext _db;
        public ClientRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public override async Task<IEnumerable<Client>> GetAll()
        {
            return await _db.Clients.Include(o=>o.Orders).ThenInclude(o=>o.OrderDetails).ToListAsync();
        }
        


    }
}
