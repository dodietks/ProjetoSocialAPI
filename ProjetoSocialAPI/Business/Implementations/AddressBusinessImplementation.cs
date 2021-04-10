using ProjetoSocialAPI.Data.Converter.Implementations;
using ProjetoSocialAPI.Data.ValueObject;
using ProjetoSocialAPI.Models;
using ProjetoSocialAPI.Repository;
using System.Collections.Generic;

namespace ProjetoSocialAPI.Business.Implementations
{
    public class AddressBusinessImplementation : IAddressBusiness
    {
        private readonly IRepository<Address> _repository;
        private readonly AddressConverter _converter;


        public AddressBusinessImplementation(IRepository<Address> repository)
        {
            _repository = repository;
            _converter = new AddressConverter();
        }

        public AddressVO Create(AddressVO address)
        {
            var addressEntity = _converter.Parse(address);
            addressEntity = _repository.Create(addressEntity);
            return _converter.Parse(addressEntity);
        }

        public List<AddressVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        public AddressVO FindByID(long id)
        {
            return _converter.Parse(_repository.FindByID(id));
        }

        public AddressVO Update(AddressVO address)
        {
            var addressEntity = _converter.Parse(address);
            addressEntity = _repository.Update(addressEntity);
            return _converter.Parse(addressEntity);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}
