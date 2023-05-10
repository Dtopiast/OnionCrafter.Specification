using OnionCrafter.Base.Entities;

namespace OnionCrafter.Specification.Repository
{
    public interface IWriteRepository<TEntity, TKey> : IBaseRepository where TEntity : IEntity<TKey>
    {
        Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken = default);

        Task<IEnumerable<TEntity>> CreateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);

        Task<bool> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);

        Task<bool> UpdateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);

        Task<bool> RemoveAsync(TEntity entity, CancellationToken cancellationToken = default);

        Task<bool> RemoveRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);
    }
}