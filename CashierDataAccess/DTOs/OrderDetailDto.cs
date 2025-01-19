using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashierDataAccess.DTOs
{
    public class OrderDetailDto
    {
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
    }
}
