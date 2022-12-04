using System;
using System.Collections.Generic;

#nullable disable

namespace UniBook.Models
{
    public partial class Payment
    {
        public long PaymentID { get; set; }
        public long OrderID { get; set; }
        public string PaymentType { get; set; }

        public virtual Order Order { get; set; }
    }
}
