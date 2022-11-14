using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INV1._1._1.Models
{
    public class Transactions
    {
        public int TransactionID { get; set; }
        public int UserID { get; set; }
        public int CustomerID { get; set; }
        public DateTime DateOfPurchase { get; set; }
        public int SalesID { get; set; }
        public decimal AmountTransacted { get; set; }

    }
}
