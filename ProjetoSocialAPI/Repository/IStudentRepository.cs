using ProjetoSocialAPI.Models;
using System.Collections.Generic;

namespace ProjetoSocialAPI.Repository
{
    public interface IStudentRepository
    {
        Student Create(Student student);
        Student FindByID(long id);
        List<Student> FindAll();
        Student Update(Student student);
        void Delete(long id);
        bool Exists(long id);

    }
}
