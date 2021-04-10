using ProjetoSocialAPI.Data.Converter.Contract;
using ProjetoSocialAPI.Data.ValueObject;
using ProjetoSocialAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoSocialAPI.Data.Converter.Implementations
{
    public class AddressConverter : IParser<AddressVO, Address>, IParser<Address, AddressVO>
    {
        public Address Parse(AddressVO origin)
        {
            if (origin is null) return null;
            return new Address
            {
                Id = origin.Id,
                PostalCode = origin.PostalCode,
                Country = origin.Country,
                State = origin.State,
                City = origin.City,
                Street = origin.Street,
                Number = origin.Number,
                Complement = origin.Complement,
                CreatedBy = origin.CreatedBy
            };
        }

        public AddressVO Parse(Address origin)
        {
            if (origin is null) return null;
            return new AddressVO
            {
                Id = origin.Id,
                PostalCode = origin.PostalCode,
                Country = origin.Country,
                State = origin.State,
                City = origin.City,
                Street = origin.Street,
                Number = origin.Number,
                Complement = origin.Complement,
                CreatedBy = origin.CreatedBy
            };
        }

        public List<Address> Parse(List<AddressVO> origin)
        {
            if (origin is null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<AddressVO> Parse(List<Address> origin)
        {
            if (origin is null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
