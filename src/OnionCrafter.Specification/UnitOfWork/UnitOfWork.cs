using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OnionCrafter.Base.Entities;
using OnionCrafter.Specification.Context;
using OnionCrafter.Specification.Repository;
using OnionCrafter.Specification.Repository.Cache;
using OnionCrafter.Specification.Utils;

namespace OnionCrafter.Specification.UnitOfWork
{
    public class UnitOfWork<TContext> : IRepositoryFactory, IUnitOfWork<TContext>
        where TContext : IBaseContext
    {
        private readonly TContext _context;
        private readonly ILogger<UnitOfWork<TContext>>? _logger;
        private readonly IRepositoryContainer _repositoryContainer;

        public UnitOfWork(TContext context, IOptions<UnitOfWorkOptions> config, ILogger<UnitOfWork<TContext>>? logger, IRepositoryContainer repositoryContainer)
        {
            _logger = logger;
            _config = config.Value;
            _repositoryContainer = repositoryContainer;
            _context = context ?? throw new ArgumentNullException(nameof(context));
            if (logger == null && _config.UseLogger)
                throw new ArgumentNullException("No loggers are registered, if your project does not require logging set the UseLogger option to false in your implementation.");
        }

        public UnitOfWorkOptions _config { get; }

        public async Task BeginAsync()
        {
            if (_config.UseLogger)
                _logger?.LogInformation(_config.BeginMessageLogger ?? "Begin transaction created");
            await _context.BeginTransactionAsync();
        }

        public async Task<bool> CommitAsync()
        {
            await _context.CommitTransactionAsync();
            var result = await _context.SaveChangesAsync();
            if (_config.UseLogger)
                //agrega la opcion de config para error
                _logger?.CreateInformationOrErrorLog(result, _config.CommitMessageLogger ?? "commit successfully submitted", "error while sending commit");
            return result;
        }

        public async Task RollbackAsync()
        {
            await _context.Database.RollbackTransactionAsync();
            if (_config.UseLogger)
                _logger?.LogInformation("Rollback successfully submitted");
        }

        public async Task<ICompleteRepository<TEntity, TKey>> GetCompleteRepositoryAsync<TEntity, TKey>()
            where TEntity : IEntity<TKey>
        {
            return await _repositoryContainer.GetOrCreateRepositoryAsync<TEntity, TKey, ICompleteRepository<TEntity, TKey>>(_context);
        }

        public async Task<IReadRepository<TEntity, TKey>> GetReadRepositoryAsync<TEntity, TKey>()
            where TEntity : IEntity<TKey>
        {
            return await _repositoryContainer.GetOrCreateRepositoryAsync<TEntity, TKey, IReadRepository<TEntity, TKey>>(_context);
        }

        public async Task<IWriteRepository<TEntity, TKey>> GetWriteRepositoryAsync<TEntity, TKey>()
            where TEntity : IEntity<TKey>
        {
            return await _repositoryContainer.GetOrCreateRepositoryAsync<TEntity, TKey, IWriteRepository<TEntity, TKey>>(_context);
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}