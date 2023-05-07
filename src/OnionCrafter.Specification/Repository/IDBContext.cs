using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using OnionCrafter.Base.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionCrafter.Specification.Repository
{
    public interface IDBContext : IDisposable
    {
        public DbSet<TEntity> Set<TEntity>() where TEntity : class, IBaseEntity;

        public Task<int> SaveChangesAsync(CancellationToken cancellationTaken = new CancellationToken());

        public EntityEntry<TEntity> Update<TEntity>(TEntity entity) where TEntity : class, IBaseEntity;

        public EntityEntry<TEntity> Remove<TEntity>(TEntity entity) where TEntity : class, IBaseEntity;

        public ValueTask<EntityEntry<TEntity>> AddAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default) where TEntity : class, IBaseEntity;
    }
}