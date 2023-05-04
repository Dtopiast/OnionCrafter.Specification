using OnionCrafter.Base.Entities;

namespace OnionCrafter.Specification
{
    public interface IReadRepository<TEntity, TKey> : IBaseRepository<TEntity> where TEntity : IEntity<TKey>
    {
    }
}