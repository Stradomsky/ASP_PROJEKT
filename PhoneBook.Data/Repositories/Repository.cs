using PhoneBookApp.Data.Configuration;
using PhoneBookApp.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace PhoneBookApp.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : EntityBase 
    {
        // CRUD - Create Read Update Delete
        private readonly PhoneBookAppContext _phoneBookAppContext;

        public Repository(PhoneBookAppContext phoneBookAppContext)
        {
            _phoneBookAppContext = phoneBookAppContext;

            _phoneBookAppContext.Database.EnsureCreated();
        }

        public List<TEntity> GetAll()
        {
            List<TEntity> entities = _phoneBookAppContext.Set<TEntity>().ToList();
            return entities;
        }

        public void Add(TEntity entity)
        {
            _phoneBookAppContext.Add(entity);
            _phoneBookAppContext.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            _phoneBookAppContext.Remove(entity);
            _phoneBookAppContext.SaveChanges();
        }

        public void SaveChanges()
        {
            _phoneBookAppContext.SaveChanges();
        }
    }
}
