using System;
using System.Collections.Generic;

#nullable disable

namespace Holiday_Maker.Models
{
    public partial class Booking
    {
        public Booking()
        {
            BookedRooms = new HashSet<BookedRoom>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public int AccomodationId { get; set; }
        public int NbrOfAdults { get; set; }
        public int? NbrOfChildren { get; set; }
        public DateTime CheckOutDate { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime? PaymentDate { get; set; }
        public DateTime? CancellationDate { get; set; }

        public virtual ICollection<BookedRoom> BookedRooms { get; set; }
    }
}
