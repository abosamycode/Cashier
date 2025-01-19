using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashierDataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IOrderRepository OrderRepository { get; }
        IOrderDetailRepository OrderDetailRepository { get; }
        IClientRepository ClientRepository { get; }
        void Save();
    }
}
