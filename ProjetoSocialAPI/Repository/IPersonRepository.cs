using ProjetoSocialAPI.Data.ValueObject;
using ProjetoSocialAPI.Models;
using System.Security.Cryptography;

namespace ProjetoSocialAPI.Repository
{
    public interface IPersonRepository
    {
        Person ValidateCredentials(PersonVO person);
        Person RefreshUserInfo(Person person);
        object ComputeHash(string input, SHA256CryptoServiceProvider sHA256CryptoServiceProvider);
    }
}
