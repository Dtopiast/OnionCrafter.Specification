using OnionCrafter.Base.DataAccess;
using OnionCrafter.Service.Services;
using OnionCrafter.Specification.Repositories.General.Options;

namespace OnionCrafter.Specification.Repositories.General
{
    /// <summary>
    /// Represents the actions that can be performed on a repository.
    /// </summary>
    public enum RepositoryAction
    {
        /// <summary>
        /// No action.
        /// </summary>
        None = 0,

        /// <summary>
        /// Action to check if any entity in the repository satisfies the given specification.
        /// </summary>
        Any,

        /// <summary>
        /// Action to retrieve entities from the repository based on the given specification.
        /// </summary>
        Get,

        /// <summary>
        /// Action to delete an entity from the repository.
        /// </summary>
        Delete,

        /// <summary>
        /// Action to update an entity in the repository.
        /// </summary>
        Update,

        /// <summary>
        /// Action to count the number of entities in the repository.
        /// </summary>
        Count
    }

    /// <summary>
    /// Interface for a base repository that implements <see cref="IBaseService"/> and <see cref="IDataAccessDetails"/>.
    /// </summary>
    public interface IBaseRepository : IBaseService, IDataAccessDetails
    {
    }

    /// <summary>
    /// Interface for a base repository that implements <see cref="IBaseRepository"/> and <see cref="IBaseService{TBaseRepositoryOptions}"/>.
    /// </summary>
    /// <typeparam name="TBaseRepositoryOptions">The type of the base repository options.</typeparam>
    public interface IBaseRepository<TBaseRepositoryOptions> : IBaseRepository, IBaseService<TBaseRepositoryOptions>
        where TBaseRepositoryOptions : IBaseRepositoryOptions
    {
    }
}