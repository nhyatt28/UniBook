using System;
using System.Collections.Generic;

#nullable disable

namespace CSSTemplateDemo1._1.Models
{
    public partial class Order
    {
        public long ID { get; set; }
        public DateTime? OrderDate { get; set; }
        public long? CustomerID { get; set; }
        public string Notes { get; set; }
    }
}
