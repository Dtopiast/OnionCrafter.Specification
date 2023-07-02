using OnionCrafter.Base.Entities;
using OnionCrafter.DataAccess.Context;
using OnionCrafter.Service.Options.Globals;
using OnionCrafter.Specification.Repositories.General;
using OnionCrafter.Specification.Repositories.General.Options;

namespace OnionCrafter.Specification.Repositories.General.Read
{
    /// <summary>
    /// Represents a read repository.
    /// </summary>
    /// <typeparam name="TKey">The type of the entity key.</typeparam>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TContext">The type of the database context.</typeparam>
    /// <typeparam name="TGlobalServiceOptions">The type of the global service options.</typeparam>

    public interface IReadRepository<TKey, TEntity, TContext, TGlobalServiceOptions> :
        IBaseReadRepository<TContext>
        where TEntity : class, IBaseEntity
        where TKey : notnull, IEquatable<TKey>, IComparable<TKey>
        where TContext : class, IBaseDataAccessContext
        where TGlobalServiceOptions : IBaseGlobalOptions

    {
        /// <summary>
        /// Checks if any entity in the repository satisfies the given specification asynchronously.
        /// </summary>
        /// <param name="specification">The specification to check.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a value indicating whether any entity satisfies the specification.</returns>
        abstract Task<bool> AnyAsync(ISpecification<TEntity, bool> specification, CancellationToken cancellationToken = default);

        /// <summary>
        /// Checks if the repository contains any entities asynchronously.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a value indicating whether the repository contains any entities.</returns>
        abstract Task<bool> AnyAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Counts the number of entities in the repository asynchronously.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the number of entities in the repository.</returns>
        abstract Task<int> CountAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves all entities from the repository asynchronously.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a collection of all entities in the repository.</returns>
        abstract Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves entities from the repository asynchronously based on the given specification.
        /// </summary>
        /// <param name="specification">The specification used to filter the entities.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a collection of entities that match the specification.</returns>
        abstract Task<IEnumerable<TEntity>> GetAllAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves an entity with the specified id asynchronously.
        /// </summary>
        /// <param name="id">The id of the entity to retrieve.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the entity with the specified id, or null if no such entity exists.</returns>
        abstract Task<TEntity?> GetByIdAsync(TKey id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves the first entity that matches the given specification asynchronously.
        /// </summary>
        /// <param name="specification">The specification used to filter the entity.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the first entity that matches the specification, or null if no such entity exists.</returns>
        abstract Task<TEntity?> GetFirstOrDefaultAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a single entity that matches the given specification asynchronously.
        /// </summary>
        /// <param name="specification">The specification used to filter the entity.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the entity that matches the specification, or null if no such entity exists.</returns>
        abstract Task<TEntity?> GetSingleOrDefaultAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default);
    }

    /// <summary>
    /// Represents a generic repository interface for read operations on entities with additional repository options.
    /// </summary>
    /// <typeparam name="TKey">The type of the entity's primary key.</typeparam>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TContext">The type of the database context.</typeparam>
    /// <typeparam name="TGlobalServiceOptions">The type of the global service options.</typeparam>
    /// <typeparam name="TRepositoryOptions">The type of the repository options.</typeparam>
    public interface IReadRepository<TKey, TEntity, TContext, TGlobalServiceOptions, TRepositoryOptions> :
        IBaseReadRepository<TContext, TRepositoryOptions>,
        IReadRepository<TKey, TEntity, TContext, TGlobalServiceOptions>
        where TEntity : class, IBaseEntity
        where TKey : notnull, IEquatable<TKey>, IComparable<TKey>
        where TRepositoryOptions : IBaseRepositoryOptions
        where TGlobalServiceOptions : IBaseGlobalOptions
        where TContext : class, IBaseDataAccessContext
    {
    }
}