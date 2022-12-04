using System;
using System.Collections.Generic;

#nullable disable

namespace CSSTemplateDemo1._1.Models
{
    public partial class Item
    {
        public long ID { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public int? Quantity { get; set; }
        public string Details { get; set; }
        public string Type { get; set; }
    }
}
