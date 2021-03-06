using System;
using System.Collections.Generic;

#nullable disable

namespace Holiday_Maker.Models
{
    public partial class User
    {
        public User()
        {
            UserRatings = new HashSet<UserRating>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string StreetAddress { get; set; }
        public int ZipCode { get; set; }
        public int MemberTypeId { get; set; }
        public long? CreditCard { get; set; }
        public int? MemberPoints { get; set; }

        public virtual ICollection<UserRating> UserRatings { get; set; }
    }
}
