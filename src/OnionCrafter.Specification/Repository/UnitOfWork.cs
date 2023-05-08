using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OnionCrafter.Base.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace OnionCrafter.Specification.Repository
{
    public class UnitOfWork<TDBContext> : IRepositoryFactory, IUnitOfWork<TDBContext>, IDisposable
        where TDBContext : notnull, IDBContext
    {
        private readonly ILogger<UnitOfWork<TDBContext>>? _logger;
        private readonly Dictionary<(Type type, string name), object> _repositories;
        private readonly UnitOfWorkOptions _options;
        private readonly TDBContext? _context;

        public UnitOfWork(TDBContext context, IOptions<UnitOfWorkOptions> options, ILogger<UnitOfWork<TDBContext>>? logger)
        {
            _logger = logger;
            _context = context;
            _options = options.Value;
            _repositories = new();
            if (_options.AutomaticallyLoadRepositories)
                LoadRepositoriesInAssembly();
            if (_context == null && _options.UseLogger)
                throw new ArgumentNullException("No loggers are registered, if your project does not require logging set the UseLogger option to false in your implementation.");
        }

        public async Task BeginAsync()
        {
            await _context.Database.BeginTransactionAsync();
        }

        public async Task<int> CommitAsync()
        {
            await _context.Database.CommitTransactionAsync();
            return await _context.SaveChangesAsync();
        }

        public IReadRepository<TEntity, TKey> GetReadRepository<TEntity, TKey>() where TEntity : IEntity<TKey>
        {
            throw new NotImplementedException();
        }

        public IRepository<TEntity, TKey> GetRepository<TEntity, TKey>() where TEntity : IEntity<TKey>
        {
            return test(new Repository)
            throw new NotImplementedException();
        }

        public IWriteRepository<TEntity, TKey> GetWriteRepository<TEntity, TKey>() where TEntity : IEntity<TKey>
        {
            throw new NotImplementedException();
        }

        public async Task RollbackAsync()
        {
            await _context.Database.RollbackTransactionAsync();
        }

        protected TRepository CreateOrGetRepository<TRepository>(TRepository repository)
        {
        }

        protected void LoadRepositoriesInAssembly()
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var types = assemblies.SelectMany(x => x.GetTypes()).Where(a => typeof(IBaseRepository).IsAssignableFrom(a) && a.IsClass)
                ?? throw new NotImplementedException();
            // var t = assemblies.Where(x=> types.Contains(x.GetType()));
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}