using System;
using System.Collections.Generic;

#nullable disable

namespace Holiday_Maker.Models
{
    public partial class UserRating
    {
        public int Id { get; set; }
        public int AccomodationId { get; set; }
        public int UserId { get; set; }
        public int Rating { get; set; }

        public virtual Accomodation Accomodation { get; set; }
        public virtual User User { get; set; }
    }
}
