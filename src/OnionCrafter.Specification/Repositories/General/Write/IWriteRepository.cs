using OnionCrafter.Base.Entities;
using OnionCrafter.DataAccess.Context;
using OnionCrafter.Service.Options.Globals;
using OnionCrafter.Specification.Repositories.General.Options;
using OnionCrafter.Specification.Repositories.General.Read;

namespace OnionCrafter.Specification.Repositories.General.Write
{
    /// <summary>
    /// Represents a generic repository interface for write operations on entities.
    /// </summary>
    /// <typeparam name="TKey">The type of the entity's primary key.</typeparam>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TGlobalServiceOptions">The type of the global service options.</typeparam>
    public interface IWriteRepository<TKey, TEntity, TContext, TGlobalServiceOptions> :
        IReadRepository<TKey, TEntity, TContext, TGlobalServiceOptions>
        where TEntity : class, IBaseEntity
        where TKey : notnull, IEquatable<TKey>, IComparable<TKey>
        where TGlobalServiceOptions : IBaseGlobalOptions
        where TContext : class, IBaseDataAccessContext

    {
        /// <summary>
        /// Creates a new entity asynchronously.
        /// </summary>
        /// <param name="entity">The entity to create.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        abstract Task CreateAsync(TEntity entity, CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates multiple entities asynchronously.
        /// </summary>
        /// <param name="entities">The entities to create.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        abstract Task CreateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates an existing entity asynchronously.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        abstract Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates multiple entities asynchronously.
        /// </summary>
        /// <param name="entities">The entities to update.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        abstract Task UpdateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);

        /// <summary>
        /// Removes an existing entity asynchronously.
        /// </summary>
        /// <param name="entity">The entity to remove.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        abstract Task RemoveAsync(TEntity entity, CancellationToken cancellationToken = default);

        /// <summary>
        /// Removes multiple entities asynchronously.
        /// </summary>
        /// <param name="entities">The entities to remove.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        abstract Task RemoveRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);
    }

    /// <summary>
    /// Represents a generic repository interface for write operations on entities with additional repository options.
    /// </summary>
    /// <typeparam name="TKey">The type of the entity's primary key.</typeparam>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TGlobalServiceOptions">The type of the global service options.</typeparam>
    /// <typeparam name="TRepositoryOptions">The type of the repository options.</typeparam>
    /// <typeparam name="TContext">The type of the database context.</typeparam>

    public interface IWriteRepository<TKey, TEntity, TContext, TGlobalServiceOptions, TRepositoryOptions> :
        IWriteRepository<TKey, TEntity, TContext, TGlobalServiceOptions>,
        IBaseWriteRepository<TContext, TRepositoryOptions>
        where TEntity : class, IBaseEntity
        where TKey : notnull, IEquatable<TKey>, IComparable<TKey>
        where TGlobalServiceOptions : IBaseGlobalOptions
        where TRepositoryOptions : IBaseRepositoryOptions
        where TContext : class, IBaseDataAccessContext
    {
    }
}