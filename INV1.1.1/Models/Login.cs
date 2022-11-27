using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace INV1._1._1.Models
{
    public class Login
    {
        public string username { get; set; }
        public string password { get; set; }
    }
    public class Users
    {
        public string username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }

        public string Password { get; set; }




        public Result result { get; set; }
    }

    public class Result
    {
        public bool result { get; set; }
        public string message { get; set; }

    }
}

//code requires edit to fix slution
