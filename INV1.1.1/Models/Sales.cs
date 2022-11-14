using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INV1._1._1.Models
{
    public class Sales
    {
        public int SalesID { get; set; }
        public int CustomerID { get; set; }
        public DateTime DateOfSale { get; set; }
        public int ProductID { get; set; }
        public decimal CostSold { get; set; }
        public decimal TotalSold { get; set; }
    }
}
