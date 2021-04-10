using ProjetoSocialAPI.Data.Converter.Contract;
using ProjetoSocialAPI.Data.ValueObject;
using ProjetoSocialAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoSocialAPI.Data.Converter.Implementations
{
    public class PersonConverter : IParser<PersonVO, Person>, IParser<Person, PersonVO>
    {
        public Person Parse(PersonVO origin)
        {
            if (origin is null) return null;
            return new Person
            {
                Id = origin.Id,
                Login = origin.Login,
                Password = origin.Password,
                Disabled = origin.Disabled,
                Student = origin.Student,
                Address = origin.Address
            };
        }

        public PersonVO Parse(Person origin)
        {
            if (origin is null) return null;
            return new PersonVO
            {
                Id = origin.Id,
                Login = origin.Login,
                Password = origin.Password,
                Disabled = origin.Disabled,
                Student = origin.Student,
                Address = origin.Address
            };
        }

        public List<Person> Parse(List<PersonVO> origin)
        {
            if (origin is null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<PersonVO> Parse(List<Person> origin)
        {
            if (origin is null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
