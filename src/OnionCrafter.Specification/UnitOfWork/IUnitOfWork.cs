using OnionCrafter.Base.Services;

namespace OnionCrafter.Specification.UnitOfWork
{
    public interface IUnitOfWork : IService<UnitOfWorkOptions>
    {
        Task<bool> CommitAsync();
    }

    public interface IUnitOfWork<TDBContext> : IUnitOfWork
    {
        Task RollbackAsync();

        Task BeginAsync();
    }
}