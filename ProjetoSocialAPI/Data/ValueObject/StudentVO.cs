using ProjetoSocialAPI.Hypermedia;
using ProjetoSocialAPI.Hypermedia.Abstract;
using ProjetoSocialAPI.Models;
using ProjetoSocialAPI.Models.Enums;
using System;
using System.Collections.Generic;

namespace ProjetoSocialAPI.Data.ValueObject
{
    public class StudentVO : ISuportsHyperMedia
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public Genders Gender { get; set; }
        public string Email { get; set; }
        public int Attendence { get; set; }
        public string AvatarUrl { get; set; }
        public BeltType Belt { get;  set; }
        public int Degree { get; set; }
        public DateTime Birthdate { get; set; }
        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}
