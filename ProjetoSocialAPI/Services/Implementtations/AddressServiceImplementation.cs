using ProjetoSocialAPI.Models;
using System;
using System.Collections.Generic;
using System.Threading;

namespace ProjetoSocialAPI.Services.Implementtations
{
    public class AddressServiceImplementation : IAddressService
    {
        private volatile int count;

        public Student Create(Student student)
        {
            return student;
        }

        public void Delete(long id)
        {
           
        }

        public List<Student> FindAll()
        {
            List<Student> students = new List<Student>();
            for (int i = 0; i < 6; i++)
            {
                Student student = MockStudent(i);
                students.Add(student);
            }
            return students;
        }


        public Student FindByID(long id)
        {
            return new Student
            {
                Id = IncrementAndGet(),
                Name = "Thomas",
                Gender = "Masculino",
                Email = "thomasklfs@gmail.com",
                Attendence =  199,
                AvatarUrl = "localhost",
                Belt = "Blue",
                Degree = 2
            };
        }

        public Student Update(Student student)
        {
            return student;
        }

        private Student MockStudent(int i)
        {
            return new Student
            {
                Id = IncrementAndGet(),
                Name = $"Thomas {i}",
                Gender = $"Masculino {i}",
                Email = $"thomasklfs@gmail.com {i}",
                Attendence = 199,
                AvatarUrl = $"localhost{i}",
                Belt = "Purple",
                Degree = i
            };
        }

        private int IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }
    }
}
