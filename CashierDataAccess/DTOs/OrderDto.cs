using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashierDataAccess.DTOs
{
    public class OrderDto
    {
        public int ClientID { get; set; }
        public double PaidAmount { get; set; }
        public double TotalAmount { get; set; }

        public DateTime DilveryTime { get; set; }
    }
}
