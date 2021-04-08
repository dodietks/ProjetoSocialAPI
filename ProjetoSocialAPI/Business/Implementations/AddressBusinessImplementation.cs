using ProjetoSocialAPI.Models;
using ProjetoSocialAPI.Repository;
using System.Collections.Generic;

namespace ProjetoSocialAPI.Business.Implementations
{
    public class AddressBusinessImplementation : IAddressBusiness
    {
        private readonly IRepository<Address> _repository;

        public AddressBusinessImplementation(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public Address Create(Address address)
        {
            return _repository.Create(address);
        }

        public List<Address> FindAll()
        {
            return _repository.FindAll();
        }

        public Address FindByID(long id)
        {
            return _repository.FindByID(id);
        }

        public Address Update(Address address)
        {
            return _repository.Update(address);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}
