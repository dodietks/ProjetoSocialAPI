using ProjetoSocialAPI.Models;
using System;
using System.Collections.Generic;
using System.Threading;

namespace ProjetoSocialAPI.Services.Implementations
{
    public class AddressServiceImplementation : IAddressService
    {
        private volatile int count;

        public Address Create(Address address)
        {
            return address;
        }

        public void Delete(long id)
        {
           
        }

        public List<Address> FindAll()
        {
            List<Address> addresses = new List<Address>();
            for (int i = 0; i < 6; i++)
            {
                Address address = MockStudent(i);
                addresses.Add(address);
            }
            return addresses;
        }

        public Address FindByID(long id)
        {
            return new Address
            {
                Id = IncrementAndGet(),
                PostalCode = $"88052-60{id}",
                Country = $"Brasil {id}",
                State = $"Santa Catarina {id}",
                City = $"Floripa {id}",
                Street = $"Rua {id}",
                Number = 1,
                Complement = $"AP {id}",
            };
        }

        public Address Update(Address address)
        {
            return address;
        }

        private Address MockStudent(int i)
        {
            return new Address
            {
                Id = IncrementAndGet(),
                PostalCode = $"88052-60{i}",
                Country = $"Brasil {i}",
                State = $"Santa Catarina {i}",
                City = $"Floripa {i}",
                Street = $"Rua {i}",
                Number = i,
                Complement = $"AP {i}",
            };
        }

        private int IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }
    }
}
