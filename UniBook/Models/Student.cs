using System;
using System.Collections.Generic;

#nullable disable

namespace UniBook.Models
{
    public partial class Student
    {
        public Student()
        {
            WishLists = new HashSet<WishList>();
        }

        public long StudentID { get; set; }
        public string StudentFirstName { get; set; }
        public string StudentLastName { get; set; }
        public string StudentType { get; set; }
        public long? SchoolID { get; set; }
        public DateTime? DOB { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int? Zipcode { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime LastActivity { get; set; }
        public long LastActivityID { get; set; }

        public virtual School School { get; set; }
        public virtual ICollection<WishList> WishLists { get; set; }
    }
}
