using ProjetoSocialAPI.Data.Converter.Contract;
using ProjetoSocialAPI.Data.ValueObject;
using ProjetoSocialAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoSocialAPI.Data.Converter.Implementations
{
    public class StudentConverter : IParser<StudentVO, Student>, IParser<Student, StudentVO>
    {
        public Student Parse(StudentVO origin)
        {
            if (origin is null) return null;
            return new Student
            {
                Id = origin.Id,
                Name = origin.Name,
                Gender = origin.Gender,
                Email = origin.Email,
                Attendence = origin.Attendence,
                AvatarUrl = origin.AvatarUrl,
                Belt = origin.Belt,
                Degree = origin.Degree,
                Birthdate = origin.Birthdate,
                CreatedBy = origin.CreatedBy
            };
        }

        public StudentVO Parse(Student origin)
        {
            if (origin is null) return null;
            return new StudentVO
            {
                Id = origin.Id,
                Name = origin.Name,
                Gender = origin.Gender,
                Email = origin.Email,
                Attendence = origin.Attendence,
                AvatarUrl = origin.AvatarUrl,
                Belt = origin.Belt,
                Degree = origin.Degree,
                Birthdate = origin.Birthdate,
                CreatedBy = origin.CreatedBy
            };
        }

        public List<Student> Parse(List<StudentVO> origin)
        {
            if (origin is null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<StudentVO> Parse(List<Student> origin)
        {
            if (origin is null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
