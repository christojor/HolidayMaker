using System;
using System.Collections.Generic;

#nullable disable

namespace Holiday_Maker.Models
{
    public partial class Room
    {
        public Room()
        {
            BookedRooms = new HashSet<BookedRoom>();
        }

        public int Id { get; set; }
        public int AccomodationId { get; set; }
        public int RoomTypeId { get; set; }
        public string ImgSrc { get; set; }
        public decimal Price { get; set; }

        public virtual Accomodation Accomodation { get; set; }
        public virtual RoomType RoomType { get; set; }
        public virtual ICollection<BookedRoom> BookedRooms { get; set; }
    }
}
