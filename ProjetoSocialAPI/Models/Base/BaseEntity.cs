using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoSocialAPI.Models.Base
{
    public class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public long Id { get; set; }
        [Required]
        [Column("deleted")]
        public bool Deleted { get; set; }
        [Required]
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
        [Column("Modificated_at")]
        public DateTime ModificatedAt { get; set; }
        [Required]
        [Column("created_by")]
        public string CreatedBy { get; set; }
        [Column("modificated_by")]
        public string ModificatedBy { get; set; }
    }
}
