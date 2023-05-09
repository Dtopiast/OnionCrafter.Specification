using OnionCrafter.Base.Entities;
using OnionCrafter.Base.Services;

namespace OnionCrafter.Specification.Repository.Cache
{
    public interface IRepositoryContainer : IService<RepositoryContainerOptions>
    {
        public Task<TRepository> GetOrCreateRepositoryAsync<TEntity, TKey, TRepository>()
            where TEntity : IEntity<TKey>
            where TRepository : IBaseRepository;

        public Task<int> CountAsync();

        public Task<bool> ContainsRepositoryAsync<TEntity, TKey, TRepository>(TRepository repository)
            where TEntity : IEntity<TKey>
            where TRepository : IBaseRepository;

        public Task<bool> RemoveRepositoryAsync<TEntity, TKey, TRepository>(TRepository repository)
            where TEntity : IEntity<TKey>
            where TRepository : IBaseRepository;
    }
}