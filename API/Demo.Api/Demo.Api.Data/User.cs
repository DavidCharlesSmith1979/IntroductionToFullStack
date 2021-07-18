using System;
using System.Collections.Generic;

#nullable disable

namespace Demo.Api.Data
{
    public partial class User
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long? AddressId { get; set; }

        public virtual Address Address { get; set; }
    }
}
