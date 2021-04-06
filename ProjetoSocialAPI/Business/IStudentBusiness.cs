using ProjetoSocialAPI.Models;
using System.Collections.Generic;

namespace ProjetoSocialAPI.Business
{
    public interface IStudentBusiness
    {
        Student Create(Student student);
        Student FindByID(long id);
        List<Student> FindAll();
        Student Update(Student student);
        void Delete(long id);

    }
}
