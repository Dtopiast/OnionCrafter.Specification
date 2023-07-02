using OnionCrafter.DataAccess.Context;
using OnionCrafter.Specification.Repositories.General.Options;

namespace OnionCrafter.Specification.Repositories.General.Write
{
    /// <summary>
    /// Represents a base write repository.
    /// </summary>
    public interface IBaseWriteRepository :
        IBaseRepository
    {
    }

    /// <summary>
    /// Represents a base write repository with a specific database context.
    /// </summary>
    /// <typeparam name="TContext">The type of the database context.</typeparam>
    public interface IBaseWriteRepository<TContext> :
        IBaseWriteRepository,
        IBaseRepository<TContext>
        where TContext : class, IBaseDataAccessContext
    {
    }

    /// <summary>
    /// Represents a base write repository with a specific base repository options.
    /// </summary>
    /// <typeparam name="TBaseRepositoryOptions">The type of the base repository options.</typeparam>
    /// <typeparam name="TContext">The type of the database context.</typeparam>

    public interface IBaseWriteRepository<TContext, TBaseRepositoryOptions> :
        IBaseWriteRepository<TContext>,
        IBaseRepository<TContext, TBaseRepositoryOptions>
        where TBaseRepositoryOptions : IBaseRepositoryOptions
        where TContext : class, IBaseDataAccessContext

    {
    }
}