using System;
using System.Collections.Generic;

#nullable disable

namespace UniBook.Models
{
    public partial class Order
    {
        public Order()
        {
            Payments = new HashSet<Payment>();
        }

        public long OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public long ListingID { get; set; }
        public long StudentID { get; set; }
        public long VendorID { get; set; }
        public long BoookID { get; set; }
        public string ShippingStatus { get; set; }

        public virtual Textbook Boook { get; set; }
        public virtual Listing Listing { get; set; }
        public virtual Vendor Vendor { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
