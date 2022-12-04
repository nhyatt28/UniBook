using System;
using System.Collections.Generic;

#nullable disable

namespace UniBook.Models
{
    public partial class School
    {
        public School()
        {
            Courses = new HashSet<Course>();
            Students = new HashSet<Student>();
        }

        public long SchoolID { get; set; }
        public string SchoolName { get; set; }
        public string SchoolType { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
