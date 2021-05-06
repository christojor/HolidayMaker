using System;
using System.Collections.Generic;

#nullable disable

namespace Holiday_Maker.Models
{
    public partial class Accomodation
    {
        public Accomodation()
        {
            Amenities = new HashSet<Amenity>();
            Extras = new HashSet<Extra>();
            Rooms = new HashSet<Room>();
        }

        public int Id { get; set; }
        public int AccomodationTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Street { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int? DistanceToBeach { get; set; }
        public int? DistanceToCenter { get; set; }
        public decimal? GuestRating { get; set; }
        public int? StarRating { get; set; }
        public string ImgSrc { get; set; }

        public virtual AccomodationType AccomodationType { get; set; }
        public virtual ICollection<Amenity> Amenities { get; set; }
        public virtual ICollection<Extra> Extras { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
