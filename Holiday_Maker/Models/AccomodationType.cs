﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Holiday_Maker.Models
{
    public partial class AccomodationType
    {
        public AccomodationType()
        {
            Accomodations = new HashSet<Accomodation>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Accomodation> Accomodations { get; set; }
    }
}
