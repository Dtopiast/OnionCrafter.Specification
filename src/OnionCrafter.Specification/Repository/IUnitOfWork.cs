using OnionCrafter.Base.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionCrafter.Specification.Repository
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