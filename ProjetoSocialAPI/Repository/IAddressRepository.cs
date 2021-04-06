using ProjetoSocialAPI.Models;
using System.Collections.Generic;

namespace ProjetoSocialAPI.Repository
{
    public interface IAddressRepository
    {
        Address Create(Address address);
        Address FindByID(long id);
        List<Address> FindAll();
        Address Update(Address address);
        void Delete(long id);
        bool Exists(long id);
    }
}
