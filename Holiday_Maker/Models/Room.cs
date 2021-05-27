using System;
using System.Collections.Generic;

#nullable disable

namespace Holiday_Maker.Models
{
    public partial class Room
    {
        public int Id { get; set; }
        public int AccomodationId { get; set; }
        public int RoomTypeId { get; set; }
        public string ImgSrc { get; set; }
        public decimal Price { get; set; }
        public int NbrOfGuests { get; set; }
        public bool IsRefundable { get; set; }
        public int NbrOfExtraBeds { get; set; }
        public string Description { get; set; }

        public virtual Accomodation Accomodation { get; set; }
        public virtual RoomType RoomType { get; set; }
    }
}
