using System;
using System.Collections.Generic;

#nullable disable

namespace Holiday_Maker.Models
{
    public partial class Amenity
    {
        public Amenity()
        {
            WifiQualities = new HashSet<WifiQuality>();
        }

        public int Id { get; set; }
        public int AccomodationId { get; set; }
        public bool Entertainment { get; set; }
        public bool KidClub { get; set; }
        public bool Gym { get; set; }
        public bool Pool { get; set; }
        public bool WiFi { get; set; }
        public bool Resturant { get; set; }

        public virtual Accomodation Accomodation { get; set; }
        public virtual ICollection<WifiQuality> WifiQualities { get; set; }
    }
}
