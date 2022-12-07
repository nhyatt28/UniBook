using System;
using System.Collections.Generic;

#nullable disable

namespace CSSTemplateDemo1._1.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public long ID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Phone { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public DateTime? DateJoined { get; set; }
        public DateTime? LastUpdate { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
