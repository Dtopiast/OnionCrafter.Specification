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
        Task<ICompleteRepository<TEntity, TKey>> GetCompleteRepositoryAsync<TEntity, TKey>() where TEntity : IEntity<TKey>;

        Task<IReadRepository<TEntity, TKey>> GetReadRepositoryAsync<TEntity, TKey>() where TEntity : IEntity<TKey>;

        Task<IWriteRepository<TEntity, TKey>> GetWriteRepositoryAsync<TEntity, TKey>() where TEntity : IEntity<TKey>;
    }
}