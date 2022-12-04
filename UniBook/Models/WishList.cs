using System;
using System.Collections.Generic;

#nullable disable

namespace UniBook.Models
{
    public partial class WishList
    {
        public int WishListID { get; set; }
        public long StudentID { get; set; }
        public long CourseMaterialID { get; set; }

        public virtual CourseMaterial CourseMaterial { get; set; }
        public virtual Student Student { get; set; }
    }
}
