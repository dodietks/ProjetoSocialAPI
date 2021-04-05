using ProjetoSocialAPI.Models;
using System.Collections.Generic;

namespace ProjetoSocialAPI.Services
{
    public interface IStudentService
    {
        Student Create(Student student);
        Student FindByID(long id);
        List<Student> FindAll();
        Student Update(Student student);
        void Delete(long id);

    }
}
