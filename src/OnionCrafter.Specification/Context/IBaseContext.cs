using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using OnionCrafter.Base.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace OnionCrafter.Specification.Context
{
    public interface IBaseContext
    {
        public IQueryable<TEntity> SetEntity<TEntity>() where TEntity : class, IBaseEntity;

        public Task<bool> SaveChangesAsync(CancellationToken cancellationTaken = default);

        public Task CommitTransactionAsync(CancellationToken cancellationTaken = default);

        public Task BeginTransactionAsync(CancellationToken cancellationTaken = default);

        public Task RollbackTransactionAsync(CancellationToken cancellationTaken = default);
    }
}