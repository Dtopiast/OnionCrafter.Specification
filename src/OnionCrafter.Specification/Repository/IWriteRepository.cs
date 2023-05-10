using OnionCrafter.Base.Entities;

namespace OnionCrafter.Specification.Repository
{
    public interface IWriteRepository<TEntity, TKey> : IBaseRepository where TEntity : IEntity<TKey>
    {
        Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken = default);

        Task<IEnumerable<TEntity>> CreateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);

        Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);

        Task UpdateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);

        Task RemoveAsync(TEntity entity, CancellationToken cancellationToken = default);

        Task RemoveRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);
    }
}