using ProjetoSocialAPI.Models;
using ProjetoSocialAPI.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ProjetoSocialAPI.Services.Implementations
{
    public class AddressServiceImplementation : IAddressService
    {
        private readonly MySQLContext _context;

        public AddressServiceImplementation(MySQLContext context)
        {
            _context = context;
        }

        public Address Create(Address address)
        {
            try
            {
                _context.Add(address);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            return address;
        }

        public List<Address> FindAll()
        {
            return _context.Addresses.ToList();
        }

        public Address FindByID(long id)
        {
            return _context.Addresses.SingleOrDefault(s => s.Id.Equals(id));
        }

        public Address Update(Address address)
        {
            if (!Exists(address.Id)) return new Address();

            var result = _context.Addresses.SingleOrDefault(s => s.Id.Equals(address.Id));

            if (result is not null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(address);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return address;
        }

        public void Delete(long id)
        {
            var result = _context.Addresses.SingleOrDefault(s => s.Id.Equals(id));

            if (result is not null)
            {
                try
                {
                    _context.Addresses.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        private bool Exists(long id)
        {
            return _context.Addresses.Any(s => s.Id.Equals(id));
        }
    }
}
