using ProjetoSocialAPI.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoSocialAPI.Models
{
    [Table("token")]
    public class Token : BaseEntity
    {
        [Required]
        [Column("token")]
        [MaxLength(255)]
        public string RefreshToken { get; set; }

        [Required]
        [Column("token_refresh_time")]
        public DateTime TokenRefreshTime { get; set; }
    }
}
