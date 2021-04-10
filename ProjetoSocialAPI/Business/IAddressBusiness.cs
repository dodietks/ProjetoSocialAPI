using ProjetoSocialAPI.Data.ValueObject;
using System.Collections.Generic;

namespace ProjetoSocialAPI.Business
{
    public interface IAddressBusiness
    {
        AddressVO Create(AddressVO address);
        AddressVO FindByID(long id);
        List<AddressVO> FindAll();
        AddressVO Update(AddressVO address);
        void Delete(long id);
    }
}
