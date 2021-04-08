using ProjetoSocialAPI.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoSocialAPI.Models
{
    [Table("address")]
    public class Address : BaseEntity
    {
        
        [Column("postal_code")]
        [MaxLength(50)]
        public string PostalCode { get; set; }

        [Column("country")]
        [MaxLength(50)]
        public string Country { get; set; }

        [Column("state")]
        [MaxLength(50)]
        public string State { get; set; }

        [Column("city")]
        [MaxLength(50)]
        public string City { get; set; }

        [Column("street")]
        [MaxLength(50)]
        public string Street { get; set; }

        [Column("number")]
        public int Number { get; set; }

        [Column("complement")]
        [MaxLength(50)]
        public string Complement { get; set; }
    }
}