using System;
using System.Collections.Generic;

#nullable disable

namespace CSSTemplateDemo1._1.Models
{
    public partial class OrderItem
    {
        public long ID { get; set; }
        public long? OrderID { get; set; }
        public long? ItemID { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }
        public string Notes { get; set; }

        public virtual Item Item { get; set; }
        public virtual Order Order { get; set; }
    }
}
