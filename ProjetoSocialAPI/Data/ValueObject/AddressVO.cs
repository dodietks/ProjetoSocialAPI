using ProjetoSocialAPI.Hypermedia;
using ProjetoSocialAPI.Hypermedia.Abstract;
using System.Collections.Generic;

namespace ProjetoSocialAPI.Data.ValueObject
{
    public class AddressVO : ISuportsHyperMedia
    {
        public long Id { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string Complement { get; set; }
        public string CreatedBy { get; set; }
        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}