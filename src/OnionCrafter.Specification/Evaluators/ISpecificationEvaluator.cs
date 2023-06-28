using OnionCrafter.Base.Entities;

namespace OnionCrafter.Specification.Evaluators
{
    /// <summary>
    /// Interface for evaluating specifications and generating a query.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface ISpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        /// <summary>
        /// Generates a query based on the provided input query and specification.
        /// </summary>
        /// <param name="inputQuery">The input query to apply the specification to.</param>
        /// <param name="spec">The specification to be evaluated.</param>
        /// <returns>The resulting query after applying the specification.</returns>
        IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> spec);
    }
}