using CashierDataAccess.Data;
using CashierDataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashierDataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppDbContext _db;

        public UnitOfWork(AppDbContext db)
        {
            _db = db;
            OrderDetailRepository = new OrderDetailRepository(_db);
            OrderRepository = new OrderRepository(_db);
            ClientRepository = new ClientRepository(_db);
        }

        public IOrderRepository OrderRepository { get; private set; }
        public IOrderDetailRepository OrderDetailRepository { get; private set; }
        public IClientRepository ClientRepository { get; private set; }


        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
