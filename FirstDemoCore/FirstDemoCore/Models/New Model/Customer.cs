using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FirstDemoCore.Models.New_Model
{
    public class Customer
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
    }
}
