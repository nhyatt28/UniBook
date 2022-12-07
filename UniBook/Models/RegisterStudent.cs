using System;
using System.Collections.Generic;

#nullable disable

namespace UniBook.Models
{
    public partial class RegisterStudent
    {
        public long StudentID { get; set; }
        public string Fname { get; set; }
        public string LName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
