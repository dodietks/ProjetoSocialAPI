using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoSocialAPI.Models
{
    [Table("person")]
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public long Id { get; set; }

        [Required]
        [Column("login")]
        [MaxLength(50)]
        public string Login { get; set; }

        [Required]
        [Column("password")]
        [MaxLength(50)]
        public string Password { get; set; }

        [Required]
        [Column("disabled")]
        public bool Disabled { get; set; }

        [Required]
        [Column("student_id")]
        public Student Student { get; set; }

        [Required]
        [Column("address_id")]
        public Address Address { get; set; }
    }
}
