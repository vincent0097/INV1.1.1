using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace INV1._1._1.Models
{
    public class Suppliers
    {
        public int SupplierID { get; set; }
        public string SupplierName { get; set; }
        public int ProductID { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
        ErrorMessage = "Invalid email format")]
        [Required]
        public string Email { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string PhoneNo { get; set; }
        public string Address { get; set; }

    }
}