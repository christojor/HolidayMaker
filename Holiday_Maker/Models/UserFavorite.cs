using System;
using System.Collections.Generic;

#nullable disable

namespace Holiday_Maker.Models
{
    public partial class UserFavorite
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int AccomodationId { get; set; }
        public string GroupName { get; set; }
    }
}
