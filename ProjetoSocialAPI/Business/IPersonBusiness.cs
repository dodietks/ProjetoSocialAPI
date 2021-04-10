using ProjetoSocialAPI.Data.ValueObject;
using System.Collections.Generic;

namespace ProjetoSocialAPI.Business
{
    public interface IPersonBusiness
    {
        PersonVO Create(PersonVO person);
        PersonVO FindByID(long id);
        List<PersonVO> FindAll();
        PersonVO Update(PersonVO person);
        void Delete(long id);
    }
}
