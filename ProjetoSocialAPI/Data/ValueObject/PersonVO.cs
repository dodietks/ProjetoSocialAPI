using ProjetoSocialAPI.Hypermedia;
using ProjetoSocialAPI.Hypermedia.Abstract;
using ProjetoSocialAPI.Models;
using System.Collections.Generic;

namespace ProjetoSocialAPI.Data.ValueObject
{
    public class PersonVO : ISuportsHyperMedia
    {
        public long Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool Disabled { get; set; }
        public Student Student { get; set; }
        public Address Address { get; set; }
        public Token Token { get; set; }
        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();

    }
}
