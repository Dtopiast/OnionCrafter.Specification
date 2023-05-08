using OnionCrafter.Base.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionCrafter.Specification.Repository
{
    public interface IRepositoryFactory
    {
        IRepository<TEntity, TKey> GetCompleteRepository<TEntity, TKey>() where TEntity : IEntity<TKey>;

        IReadRepository<TEntity, TKey> GetReadRepository<TEntity, TKey>() where TEntity : IEntity<TKey>;

        IWriteRepository<TEntity, TKey> GetWriteRepository<TEntity, TKey>() where TEntity : IEntity<TKey>;
    }
}