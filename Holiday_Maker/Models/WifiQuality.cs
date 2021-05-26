using System;
using System.Collections.Generic;

#nullable disable

namespace Holiday_Maker.Models
{
    public partial class WifiQuality
    {
        public int Id { get; set; }
        public int AmenityId { get; set; }
        public int WifiRating { get; set; }
        public decimal Mbps { get; set; }
        public bool IsFree { get; set; }

        public virtual Amenity Amenity { get; set; }
    }
}
