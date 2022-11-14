using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INV1._1._1.Models
{
    public class Purchases
    {
        public int PurchaseID { get; set; }
        public int SupplierID { get; set; }
        public int ProductID { get; set; }
        public int CostOfPurchase { get; set; }
        public int TotalCost { get; set; }
        public DateTime DateOfPurchase { get; set; }
    }
}
