using OnionCrafter.Base.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionCrafter.Specification.Repository
{
    public class UnitOfWork<TDBContext> : IRepositoryFactory, IUnitOfWork<TDBContext>
        where TDBContext : IDBContext
    {
        private readonly ILogger<UnitOfWork<TDBContext>>? _logger;
        private readonly UnitOfWorkOptions _options;
        private readonly TDBContext _context;

        public UnitOfWork(TDBContext context, IOptions<UnitOfWorkOptions> options, ILogger<UnitOfWork<TDBContext>>? logger)
        {
            _logger = logger;
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _options = options.Value;
            if (_logger == null && _options.UseLogger)
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

        public async Task RollbackAsync()
        {
            await _context.Database.RollbackTransactionAsync();
        }


        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}