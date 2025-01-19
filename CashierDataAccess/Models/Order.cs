using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CashierDataAccess.Models
{
    public class Order

    {
        public int Id { get; set; } 
        public int ClientID { get; set; } 
        public double PaidAmount { get; set; }
        public double TotalAmount { get; set; }

        public DateTime DilveryTime { get; set; }

        [ForeignKey(nameof(ClientID))]
        [JsonIgnore]
        public Client Client { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }


    }
}
