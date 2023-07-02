using OnionCrafter.DataAccess.Context;
using OnionCrafter.Specification.Repositories.General.Options;

namespace OnionCrafter.Specification.Repositories.General.Read
{
    public interface IBaseReadRepository :
       IBaseRepository

    {
    }

    public interface IBaseReadRepository<TContext> :
        IBaseRepository<TContext>,
        IBaseReadRepository
        where TContext : class, IBaseDataAccessContext

    {
    }

    public interface IBaseReadRepository<TContext, TBaseRepositoryOptions> :
      IBaseReadRepository<TContext>,
      IBaseRepository<TContext, TBaseRepositoryOptions>
      where TContext : class, IBaseDataAccessContext
      where TBaseRepositoryOptions : IBaseRepositoryOptions

    {
    }
}