using ProjetoSocialAPI.Models;
using System.Collections.Generic;
using System.Threading;

namespace ProjetoSocialAPI.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private volatile int count;

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
           
        }

        public List<Person> FindAll()
        {
            List<Person> persons = new List<Person>();
            for (int i = 0; i < 6; i++)
            {
                Person person = MockStudent(i);
                persons.Add(person);
            }
            return persons;
        }


        public Person FindByID(long id)
        {
            return new Person
            {
                Login = IncrementAndGet(),
                Password = "Senha@forte",
                Disabled = false,
                Student = new Student
                {
                    Id = IncrementAndGet(),
                    Name = "Thomas",
                    Gender = "Masculino",
                    Email = "thomasklfs@gmail.com",
                    Attendence = 199,
                    AvatarUrl = "localhost",
                    Belt = "Blue",
                    Degree = 2
                },
                Address = new Address
                {
                    Id = IncrementAndGet(),
                    PostalCode = $"88052-60{id}",
                    Country = $"Brasil {id}",
                    State = $"Santa Catarina {id}",
                    City = $"Floripa {id}",
                    Street = $"Rua {id}",
                    Number = 1,
                    Complement = $"AP {id}",
                },
            };
        }

        public Person Update(Person person)
        {
            return person;
        }

        private Person MockStudent(int i)
        {
            return new Person
            {
                Login = IncrementAndGet(),
                Password = $"Senha@forte{i}",
                Disabled = false,
                Student = new Student
                {
                    Id = IncrementAndGet(),
                    Name = $"Thomas {i}",
                    Gender = $"Masculino {i}",
                    Email = $"thomasklfs@gmail.com {i}",
                    Attendence = 199,
                    AvatarUrl = $"localhost{i}",
                    Belt = "Purple",
                    Degree = i
                },
                Address = new Address
                {
                    Id = IncrementAndGet(),
                    PostalCode = $"88052-60{i}",
                    Country = $"Brasil {i}",
                    State = $"Santa Catarina {i}",
                    City = $"Floripa {i}",
                    Street = $"Rua {i}",
                    Number = i,
                    Complement = $"AP {i}"
                },
            };
        }

        private int IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }
    }
}
