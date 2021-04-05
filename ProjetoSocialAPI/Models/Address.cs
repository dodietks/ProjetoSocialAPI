namespace ProjetoSocialAPI.Models
{
    public class Address : BaseEntity
    {
        public long Id { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string Complement { get; set; }
    }
}