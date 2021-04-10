using ProjetoSocialAPI.Data.Converter.Implementations;
using ProjetoSocialAPI.Data.ValueObject;
using ProjetoSocialAPI.Models;
using ProjetoSocialAPI.Repository;
using System.Collections.Generic;

namespace ProjetoSocialAPI.Business.Implementations
{
    public class StudentBusinessImplementation : IStudentBusiness
    {
        private readonly IRepository<Student> _repository;
        private readonly StudentConverter _converter;

        public StudentBusinessImplementation(IRepository<Student> repository)
        {
            _repository = repository;
            _converter = new StudentConverter();
        }

        public StudentVO Create(StudentVO student)
        {
            var studentEntity = _converter.Parse(student);
            studentEntity = _repository.Create(studentEntity);
            return _converter.Parse(studentEntity);
        }

        public List<StudentVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        public StudentVO FindByID(long id)
        {
            return _converter.Parse(_repository.FindByID(id));
        }

        public StudentVO Update(StudentVO student)
        {
            var studentEntity = _converter.Parse(student);
            studentEntity = _repository.Update(studentEntity);
            return _converter.Parse(studentEntity);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}
