namespace ProjetoSocialAPI.Models
{
    public class Person : Student
    {
        public long Login { get; set; }
        public string Password { get; set; }
        public bool IsComplete { get; set; }
        public Student Student { get; set; }
        public Address Address { get; set; }
    }
}
