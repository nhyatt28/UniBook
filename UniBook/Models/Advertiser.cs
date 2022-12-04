using System;
using System.Collections.Generic;

#nullable disable

namespace UniBook.Models
{
    public partial class Advertiser
    {
        public Advertiser()
        {
            Advertisements = new HashSet<Advertisement>();
        }

        public long AdvertiserID { get; set; }
        public string CompanyName { get; set; }
        public string Industry { get; set; }

        public virtual ICollection<Advertisement> Advertisements { get; set; }
    }
}
