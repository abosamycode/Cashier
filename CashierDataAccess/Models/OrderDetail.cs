using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CashierDataAccess.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderID { get; set; }
        public double Length { get; set; }
        public double NumberofTops { get; set; }
        public double Shoulder { get; set; }
        public double SleeveLength { get; set; }
        public double CollarSize { get; set; }
        public double SizeOfNeck { get; set; }
        public double ChestExpansion { get; set; }
        public double HandExpansion { get; set; }
        public double KikLength { get; set; }

        [ForeignKey(nameof(OrderID))]
        [JsonIgnore]
        public Order Order { get; set; }


    }
}
