using OnionCrafter.Base.Entities;
using OnionCrafter.Specification.Repository.Base;

namespace OnionCrafter.Specification.Repository
{
    public interface IReadRepository<TEntity, TKey> : IBaseRepository where TEntity : IEntity<TKey>
    {
        Task<TEntity?> GetByIdAsync(TKey id, CancellationToken cancellationToken = default);

        Task<TEntity?> GetFirstOrDefaultAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default);

        Task<TEntity?> GetSingleOrDefaultAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default);

        Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<IEnumerable<TEntity>> GetAllAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default);

        Task<int> CountAsync(CancellationToken cancellationToken = default);

        Task<bool> AnyAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default);

        Task<bool> AnyAsync(CancellationToken cancellationToken = default);
    }
}