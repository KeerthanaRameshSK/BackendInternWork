using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class Customer
    {
        public int AadharNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Age { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
    }
}
