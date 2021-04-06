using ProjetoSocialAPI.Models;
using ProjetoSocialAPI.Models.Context;
using ProjetoSocialAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoSocialAPI.Business.Implementations
{
    public class AddressBusinessImplementation : IAddressBusiness
    {
        private readonly IAddressRepository _repository;

        public AddressBusinessImplementation(IAddressRepository repository)
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
