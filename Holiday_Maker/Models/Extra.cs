using System;
using System.Collections.Generic;

#nullable disable

namespace Holiday_Maker.Models
{
    public partial class Extra
    {
        public int Id { get; set; }
        public int AccomodationId { get; set; }
        public bool? SelfCatering { get; set; }
        public bool? HalfBoard { get; set; }
        public bool? FullBoard { get; set; }
        public bool? AllInclusive { get; set; }
        public bool? Breakfast { get; set; }
        public bool? ExtraBed { get; set; }
        public bool Crib { get; set; }

        public virtual Accomodation Accomodation { get; set; }
    }
}
