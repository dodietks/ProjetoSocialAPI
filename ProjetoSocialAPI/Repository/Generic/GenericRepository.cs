using Microsoft.EntityFrameworkCore;
using ProjetoSocialAPI.Models.Base;
using ProjetoSocialAPI.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoSocialAPI.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly MySQLContext _context;

        private readonly DbSet<T> dataset;

        public GenericRepository(MySQLContext context)
        {
            _context = context;
            dataset = _context.Set<T>();
        }
        public T Create(T item)
        {
            try
            {
                dataset.Add(item);
                _context.SaveChanges();
                return item;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<T> FindAll()
        {
            return dataset.ToList();
        }

        public T FindByID(long id)
        {
            return dataset.SingleOrDefault(t => t.Id.Equals(id));
        }

        public T Update(T item)
        {
            var result = dataset.SingleOrDefault(t => t.Id.Equals(item.Id));
            if (result is not null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(item);
                    _context.SaveChanges();
                    return result;
                }
                catch (Exception)
                {
                    throw;
                }
            } else
            {
                return null;
            }
        }

        public void Delete(long id)
        {
            var result = dataset.SingleOrDefault(t => t.Id.Equals(id));
            if (result is not null)
            {
                try
                {
                    dataset.Remove(result);
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
            return dataset.Any(s => s.Id.Equals(id));
        }
    }
}
