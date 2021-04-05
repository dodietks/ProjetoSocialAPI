using ProjetoSocialAPI.Models;
using System.Collections.Generic;

namespace ProjetoSocialAPI.Services
{
    public interface IAddressService
    {
        Address Create(Address address);
        Address FindByID(long id);
        List<Address> FindAll();
        Address Update(Address address);
        void Delete(long id);
    }
}
