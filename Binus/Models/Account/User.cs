using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Binus.Models.Account
{
    public class User
    {
        public int userID { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string role { get; set; }
        public string fullname { get; set; }
    }
}