using OnionCrafter.Base.Entities;
using System.Linq.Expressions;

namespace OnionCrafter.Specification
{
    /// <summary>
    /// Base implementation of the <see cref="ISpecification{TEntity}"/> interface for specifying criteria, includes, and ordering for querying entities.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public class BaseSpecification<TEntity> :
        ISpecification<TEntity>
        where TEntity : IBaseEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseSpecification{TEntity}"/> class.
        /// </summary>
        public BaseSpecification()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseSpecification{TEntity}"/> class with the specified criteria.
        /// </summary>
        /// <param name="criteria">The criteria expression.</param>
        public BaseSpecification(Expression<Func<TEntity, bool>> criteria)
        {
            Criteria = criteria;
        }

        /// <summary>
        /// Gets the criteria expression for filtering entities.
        /// </summary>
        public Expression<Func<TEntity, bool>>? Criteria { get; }

        /// <summary>
        /// Gets the list of include expressions for eager loading related entities.
        /// </summary>
        public List<Expression<Func<TEntity, object>>> Includes { get; } = new List<Expression<Func<TEntity, object>>>();

        /// <summary>
        /// Gets or sets the order by expression for ordering entities in ascending order.
        /// </summary>
        public Expression<Func<TEntity, object>>? OrderBy { get; private set; }

        /// <summary>
        /// Gets or sets the order by descending expression for ordering entities in descending order.
        /// </summary>
        public Expression<Func<TEntity, object>>? OrderByDescending { get; private set; }

        /// <summary>
        /// Adds an include expression to eagerly load a related entity.
        /// </summary>
        /// <param name="includeExpression">The include expression.</param>
        protected void AddInclude(Expression<Func<TEntity, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }

        /// <summary>
        /// Sets the order by expression for ordering entities in ascending order.
        /// </summary>
        /// <param name="orderByExpression">The order by expression.</param>
        protected void AddOrderBy(Expression<Func<TEntity, object>> orderByExpression)
        {
            OrderBy = orderByExpression;
        }

        /// <summary>
        /// Sets the order by descending expression for ordering entities in descending order.
        /// </summary>
        /// <param name="orderByDescExpression">The order by descending expression.</param>
        protected void AddOrderByDescending(Expression<Func<TEntity, object>> orderByDescExpression)
        {
            OrderByDescending = orderByDescExpression;
        }
    }
}