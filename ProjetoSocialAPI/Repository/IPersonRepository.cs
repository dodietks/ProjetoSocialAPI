using ProjetoSocialAPI.Data.ValueObject;
using ProjetoSocialAPI.Models;

namespace ProjetoSocialAPI.Repository
{
    public interface IPersonRepository
    {
        Person ValidateCredentials(PersonVO person);
        Person RefreshUserInfo(Person person);
    }
}
