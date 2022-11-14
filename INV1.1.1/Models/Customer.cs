using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INV1._1._1.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Home { get; set; }

        public DateTime DateOfJoining { get; set; }

        //public string PhotoFileName
        //{
        //    get; set;
        //}
    }
}
