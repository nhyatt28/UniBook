using System;
using System.Collections.Generic;

#nullable disable

namespace UniBook.Models
{
    public partial class Vendor
    {
        public Vendor()
        {
            Orders = new HashSet<Order>();
        }

        public long VendorID { get; set; }
        public string CompanyName { get; set; }
        public string CompanyType { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string ShippingAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
