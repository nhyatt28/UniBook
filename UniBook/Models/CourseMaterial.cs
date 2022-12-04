using System;
using System.Collections.Generic;

#nullable disable

namespace UniBook.Models
{
    public partial class CourseMaterial
    {
        public CourseMaterial()
        {
            WishLists = new HashSet<WishList>();
        }

        public long CourseMaterialID { get; set; }
        public long CourseID { get; set; }
        public long BookID { get; set; }
        public byte[] RequiredText { get; set; }

        public virtual Textbook Book { get; set; }
        public virtual Course Course { get; set; }
        public virtual ICollection<WishList> WishLists { get; set; }
    }
}
