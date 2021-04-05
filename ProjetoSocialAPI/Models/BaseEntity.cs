using System;

namespace ProjetoSocialAPI.Models
{
    public class BaseEntity
    {
        public bool Deleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModificatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string ModificatedBy { get; set; }

    }
}
