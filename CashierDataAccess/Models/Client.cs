using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashierDataAccess.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhonNumber { get; set; }
        public ICollection<Order> Orders { get; set; }

    }
}
