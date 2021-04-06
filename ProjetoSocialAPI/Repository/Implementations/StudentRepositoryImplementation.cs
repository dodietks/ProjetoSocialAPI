using ProjetoSocialAPI.Models;
using ProjetoSocialAPI.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoSocialAPI.Repository.Implementations
{
    public class StudentRepositoryImplementation : IStudentRepository
    {
        private readonly MySQLContext _context;

        public StudentRepositoryImplementation(MySQLContext context)
        {
            _context = context;
        }

        public Student Create(Student student)
        {
            try
            {
                _context.Add(student);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            return student;
        }

        public List<Student> FindAll()
        {
            return _context.Students.ToList();
        }

        public Student FindByID(long id)
        {
            return _context.Students.SingleOrDefault(s => s.Id.Equals(id));
        }

        public Student Update(Student student)
        {
            if (!Exists(student.Id)) return new Student();

            var result = _context.Students.SingleOrDefault(s => s.Id.Equals(student.Id));

            if (result is not null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(student);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return student;
        }

        public void Delete(long id)
        {
            var result = _context.Students.SingleOrDefault(s => s.Id.Equals(id));

            if (result is not null)
            {
                try
                {
                    _context.Students.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public bool Exists(long id)
        {
            return _context.Students.Any(s => s.Id.Equals(id));
        }
    }
}
