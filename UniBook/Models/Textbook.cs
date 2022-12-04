using System;
using System.Collections.Generic;

#nullable disable

namespace UniBook.Models
{
    public partial class Textbook
    {
        public Textbook()
        {
            CourseMaterials = new HashSet<CourseMaterial>();
            Orders = new HashSet<Order>();
        }

        public long BookID { get; set; }
        public long ISBN { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public short? Edition { get; set; }
        public string Condition { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<CourseMaterial> CourseMaterials { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
