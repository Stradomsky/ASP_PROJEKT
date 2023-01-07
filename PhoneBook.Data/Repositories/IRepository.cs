using PhoneBookApp.Data.Entities;
using System.Collections.Generic;

namespace PhoneBookApp.Data.Repositories
{
    public interface IRepository<TEntity> where TEntity : EntityBase
    {
        List<TEntity> GetAll();

        void Add(TEntity entity);

        void Delete(TEntity entity);

        void SaveChanges();
    }
}
