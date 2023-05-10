using OnionCrafter.Base.Entities;
using OnionCrafter.Specification.Repository;

namespace OnionCrafter.Specification
{
    public interface ICompleteRepository<TEntity, TKey> : IWriteRepository<TEntity, TKey>, IReadRepository<TEntity, TKey>
        where TEntity : IEntity<TKey>

    {
    }
}