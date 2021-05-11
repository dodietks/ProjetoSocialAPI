using ProjetoSocialAPI.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoSocialAPI.Models
{
    [Table("person")]
    public class Person : BaseEntity
    {
        [Required]
        [Column("login")]
        [MaxLength(50)]
        public string Login { get; set; }

        [Required]
        [Column("password")]
        [MaxLength(255)]
        public string Password { get; set; }

        [Required]
        [Column("disabled")]
        public bool Disabled { get; set; }

        [Column("student_id")]
        public Student Student { get; set; }

        [Column("address_id")]
        public Address Address { get; set; }

        [Column("token_id")]
        public Token Token { get; set; }
    }
}
