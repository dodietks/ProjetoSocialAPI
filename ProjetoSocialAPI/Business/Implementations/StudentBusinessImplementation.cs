using ProjetoSocialAPI.Models;
using ProjetoSocialAPI.Repository;
using System.Collections.Generic;

namespace ProjetoSocialAPI.Business.Implementations
{
    public class StudentBusinessImplementation : IStudentBusiness
    {
        private readonly IStudentRepository _repository;

        public StudentBusinessImplementation(IStudentRepository repository)
        {
            _repository = repository;
        }

        public Student Create(Student student)
        {
            return _repository.Create(student);
        }

        public List<Student> FindAll()
        {
            return _repository.FindAll();
        }

        public Student FindByID(long id)
        {
            return _repository.FindByID(id);
        }

        public Student Update(Student student)
        {
            return _repository.Update(student);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}
