using OnionCrafter.Base.Entities;

namespace OnionCrafter.Specification
{
    /// <summary>
    /// Interface for a base specification that specifies criteria, includes, and ordering for querying entities.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IBaseSpecification<TEntity>
        where TEntity : IBaseEntity
    {
    }
}