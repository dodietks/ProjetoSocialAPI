namespace ProjetoSocialAPI.Models
{
    public class Student : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public int Attendence { get; set; }
        public string AvatarUrl { get; set; }
        public string Belt { get; set; }
        public int Degree { get; set; }
    }
}
