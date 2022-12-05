using System;
using System.Collections.Generic;

#nullable disable

namespace UniBook.Models
{
    public partial class RegisterStudent
    {
        public long StudentID { get; set; }
        public string FName { get; set; }
        public string MI { get; set; }
        public string LName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public long SchoolID { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public DateTime? GradYear { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
