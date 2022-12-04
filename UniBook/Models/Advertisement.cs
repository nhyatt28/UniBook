using System;
using System.Collections.Generic;

#nullable disable

namespace UniBook.Models
{
    public partial class Advertisement
    {
        public long AdvertisementID { get; set; }
        public long AdvertiserID { get; set; }
        public DateTime? AdvertisementStart { get; set; }
        public DateTime? AdvertisementEnd { get; set; }
        public string AdvertisementType { get; set; }

        public virtual Advertiser Advertiser { get; set; }
    }
}
