using OnionCrafter.Base.Entities;
using System.Linq.Expressions;

namespace OnionCrafter.Specification
{
    /// <summary>
    /// Interface for specifying criteria, includes, and ordering for querying entities.
    /// </summary>
    /// <typeparam name="Entity">The type of the entity.</typeparam>
    public interface ISpecification<Entity>
        where Entity : IBaseEntity
    {
        /// <summary>
        /// Gets the criteria expression for filtering entities.
        /// </summary>
        Expression<Func<Entity, bool>>? Criteria { get; }

        /// <summary>
        /// Gets the list of include expressions for eager loading related entities.
        /// </summary>
        List<Expression<Func<Entity, object>>> Includes { get; }

        /// <summary>
        /// Gets the order by expression for ordering entities in ascending order.
        /// </summary>
        Expression<Func<Entity, object>>? OrderBy { get; }

        /// <summary>
        /// Gets the order by descending expression for ordering entities in descending order.
        /// </summary>
        Expression<Func<Entity, object>>? OrderByDescending { get; }
    }
}