using ProjetoSocialAPI.Models;
using System.Collections.Generic;

namespace ProjetoSocialAPI.Business
{
    public interface IAddressBusiness
    {
        Address Create(Address address);
        Address FindByID(long id);
        List<Address> FindAll();
        Address Update(Address address);
        void Delete(long id);
    }
}
