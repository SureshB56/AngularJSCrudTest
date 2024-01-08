using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularJSTest.Models
{
    public class UserInfo
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public string PostalCode { get; set; }
        public int UserTableID { get; set; }

        public string Action { get; set; }
    }
}