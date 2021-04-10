using ProjetoSocialAPI.Data.ValueObject;
using ProjetoSocialAPI.Hypermedia;
using ProjetoSocialAPI.Hypermedia.Abstract;
using System.Collections.Generic;

namespace ProjetoSocialAPI.Business
{
    public interface IStudentBusiness //: ISuportsHyperMedia
    {
        StudentVO Create(StudentVO student);
        StudentVO FindByID(long id);
        List<StudentVO> FindAll();
        StudentVO Update(StudentVO student);
        void Delete(long id);
        //public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}
