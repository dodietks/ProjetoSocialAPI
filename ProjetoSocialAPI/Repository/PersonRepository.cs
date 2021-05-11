using ProjetoSocialAPI.Data.ValueObject;
using ProjetoSocialAPI.Models;
using ProjetoSocialAPI.Models.Context;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace ProjetoSocialAPI.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly MySQLContext _mySQLContext;

        public PersonRepository(MySQLContext mySQLContext)
        {
            _mySQLContext = mySQLContext;
        }

        public Person ValidateCredentials(PersonVO person)
        {
            var password = ComputeHash(person.Password, new SHA256CryptoServiceProvider());
            return _mySQLContext.Persons.FirstOrDefault(p => (p.Login == person.Login) && (p.Password == password.ToString()));
        }

        public object ComputeHash(string input, SHA256CryptoServiceProvider sHA256CryptoServiceProvider)
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashBytes = sHA256CryptoServiceProvider.ComputeHash(inputBytes);
            return BitConverter.ToString(hashBytes);
        }

        public Person RefreshUserInfo(Person person)
        {
            if (!_mySQLContext.Persons.Any(p => p.Id.Equals(person.Id))) return null;

            Person result = _mySQLContext.Persons.SingleOrDefault(p => person.Id.Equals(person.Id));
            if (result is not null)
            {
                try
                {
                    _mySQLContext.Entry(result).CurrentValues.SetValues(person);
                    _mySQLContext.SaveChanges();
                    return result;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return result;
        }
    }
}
