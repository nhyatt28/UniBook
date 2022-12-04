using System;
using System.Collections.Generic;

#nullable disable

namespace UniBook.Models
{
    public partial class Listing
    {
        public Listing()
        {
            Orders = new HashSet<Order>();
        }

        public long ListingID { get; set; }
        public DateTime ListingDate { get; set; }
        public long VendorID { get; set; }
        public long? BookID { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
