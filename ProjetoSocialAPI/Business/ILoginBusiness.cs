using ProjetoSocialAPI.Data.ValueObject;

namespace ProjetoSocialAPI.Business
{
    public interface ILoginBusiness
    {
        TokenVO ValidateCredentials(PersonVO person);
    }
}
