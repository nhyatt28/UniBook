using System;
using System.Collections.Generic;

#nullable disable

namespace UniBook.Models
{
    public partial class Course
    {
        public Course()
        {
            CourseMaterials = new HashSet<CourseMaterial>();
        }

        public long CourseID { get; set; }
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }
        public long SchoolID { get; set; }

        public virtual School School { get; set; }
        public virtual ICollection<CourseMaterial> CourseMaterials { get; set; }
    }
}
