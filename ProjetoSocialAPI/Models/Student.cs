using ProjetoSocialAPI.Models.Base;
using ProjetoSocialAPI.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoSocialAPI.Models
{
    [Table("student")]
    public class Student : BaseEntity 
    {
        [Column("name")]
        [MaxLength(250)]
        public string Name { get; set; }

        [Column("gender")]
        public Genders Gender { get; set; }

        [Column("email")]
        [MaxLength(50)]
        public string Email { get; set; }

        [Column("attendence")]
        public int Attendence { get; set; }

        [Column("avatarUrl")]
        [MaxLength(255)]
        public string AvatarUrl { get; set; }

        [Column("belt")]
        public BeltType Belt { get;  set; }

        [Column("degee")]
        public int Degree { get; set; }

        [Column("birthdate")]
        public DateTime Birthdate { get; set; }
    }
}
