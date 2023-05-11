using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OnionCrafter.Base.Entities;
using OnionCrafter.Specification.Context;
using OnionCrafter.Specification.Utils;
using System.Collections.Concurrent;

namespace OnionCrafter.Specification.Repository.Cache
{
    public class RepositoryContainer : IRepositoryContainer
    {
        private readonly ILogger<RepositoryContainer>? _logger;
        private readonly ConcurrentDictionary<string, object> _repositories;
        public RepositoryContainerOptions _config { get; }

        public RepositoryContainer(ILogger<RepositoryContainer>? logger, IOptions<RepositoryContainerOptions> config)
        {
            _repositories = new ConcurrentDictionary<string, object>();
            _config = config.Value;
            _logger = logger;
            if (logger == null && _config.UseLogger)
                throw new ArgumentNullException("No loggers are registered, if your project does not require logging set the UseLogger option to false in your implementation.");
        }

        public async Task<int> CountAsync()
        {
            return await Task.Run(() => _repositories.Count());
        }

        public async Task<TRepository> GetOrCreateRepositoryAsync<TEntity, TKey, TRepository>(IBaseContext context)
            where TEntity : IEntity<TKey>
            where TRepository : IBaseRepository
        {
            return await Task.Run(() =>
            {
                //probablemente nada de esto funcione
                TRepository? result = default;
                bool actionResult = false;
                var repositoryType = typeof(TRepository);
                string nameEntity = nameof(TEntity);

                if (_config.UseLogger)
                    _logger?.LogInformation($"Starts the process of obtaining the {nameEntity} repository");

                if (_repositories.TryGetValue(repositoryType, out var getRepository))
                {
                    result = (TRepository)(ICompleteRepository<TEntity, TKey>)getRepository;
                }
                else if (_config.AutomaticallyRegisterRepositories)
                {
                    Repository<TEntity, TKey> newRepository = new Repository<TEntity, TKey>(context);
                    _repositories.GetOrAdd(repositoryType, newRepository);
                    //agrega el log de creacion
                    result = (TRepository)(ICompleteRepository<TEntity, TKey>)newRepository;
                    actionResult = result != null;
                }

                if (_config.UseLogger)
                    _logger?.CreateInformationOrErrorLog(actionResult, "repository was obtain", "repository wasn't obtain", nameEntity);
                _ = result ?? throw new InvalidOperationException();
                return result;
            });
        }

        public async Task<bool> ContainsRepositoryAsync<TEntity, TKey, TRepository>(TRepository repository)
            where TEntity : IEntity<TKey>
            where TRepository : IBaseRepository
        {
            return await Task.Run(() =>
            {
                string nameEntity = repository.GetType().Name;
                var actionResult = _repositories.ContainsKey(repository.GetType());
                if (_config.UseLogger)
                    _logger?.CreateInformationOrErrorLog(actionResult, "repository is registered", "repository is not registered", nameEntity);
                return actionResult;
            });
        }

        public async Task<bool> RemoveRepositoryAsync<TEntity, TKey, TRepository>(TRepository repository)
            where TEntity : IEntity<TKey>
            where TRepository : IBaseRepository
        {
            return await Task.Run(() =>
            {
                string nameEntity = repository.GetType().Name;
                var actionResult = _repositories.TryRemove(repository.GetType(), out var t);
                if (_config.UseLogger)
                    _logger?.CreateInformationOrErrorLog(actionResult, "repository was remove", "repository wasn't remove", nameEntity);
                return actionResult;
            });
        }
    }
}