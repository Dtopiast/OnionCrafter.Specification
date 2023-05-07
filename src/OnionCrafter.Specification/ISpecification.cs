using OnionCrafter.Base.Entities;
using System.Linq.Expressions;

namespace OnionCrafter.Specification
{
    public interface ISpecification<Entity> where Entity : IBaseEntity
    {
        Expression<Func<Entity, bool>>? Criteria { get; }
        List<Expression<Func<Entity, object>>> Includes { get; }
        Expression<Func<Entity, object>>? OrderBy { get; }
        Expression<Func<Entity, object>>? OrderByDescending { get; }
    }
}