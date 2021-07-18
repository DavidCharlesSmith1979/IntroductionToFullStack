using System;
using System.Collections.Generic;

#nullable disable

namespace Demo.Api.Data
{
    public partial class Address
    {
        public Address()
        {
            Users = new HashSet<User>();
        }

        public long Id { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
        public string County { get; set; }
        public string Postcode { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
