using System;
using System.Collections.Generic;

#nullable disable

namespace Holiday_Maker.Models
{
    public partial class BookedRoom
    {
        public int Id { get; set; }
        public int BookingId { get; set; }
        public int RoomId { get; set; }

        public virtual Booking Booking { get; set; }
    }
}
