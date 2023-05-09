using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using OnionCrafter.Base.Entities;

namespace OnionCrafter.Specification.Context
{
    public interface IDBContext : IDisposable
    {
        public DatabaseFacade Database { get; }

        public DbSet<TEntity> Set<TEntity>() where TEntity : class, IBaseEntity;

        public Task<int> SaveChangesAsync(CancellationToken cancellationTaken = new CancellationToken());

        public EntityEntry<TEntity> Update<TEntity>(TEntity entity) where TEntity : class, IBaseEntity;

        public EntityEntry<TEntity> Remove<TEntity>(TEntity entity) where TEntity : class, IBaseEntity;

        public ValueTask<EntityEntry<TEntity>> AddAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default) where TEntity : class, IBaseEntity;
    }
}