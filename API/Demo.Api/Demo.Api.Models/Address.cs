using System;
namespace Demo.Api.Models
{
    public class Address
    {
        public long Id { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
        public string County { get; set; }
        public string Postcode { get; set; }
    }
}
