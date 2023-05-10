using OnionCrafter.Base.Entities;
using OnionCrafter.Specification.Context;

namespace OnionCrafter.Specification.Repository
{
    public class Repository<TEntity, TKey> : ICompleteRepository<TEntity, TKey>
        where TEntity : IEntity<TKey>
    {
        private readonly IBaseContext _context;

        public Repository(IBaseContext context, RepositoryPrivilegesType repositoryPrivileges, RepositoryOriginType repositoryOrigin, string? repositoryName = null)
        {
            _context = context;
            RepositoryOrigin = repositoryOrigin;
            RepositoryPrivileges = repositoryPrivileges;
            RepositoryName = CreateRepositoryName(repositoryName);
        }

        public RepositoryPrivilegesType RepositoryPrivileges { get; }
        public RepositoryOriginType RepositoryOrigin { get; }
        public string RepositoryName { get; }

        {
            _context = context;
            RepositoryPrivileges = repositoryPrivilege;
            RepositoryOriginType = repositoryOriginType;
            RepositoryName = repositoryName ?? nameof(TEntity);
        }

        public RepositoryPrivilegesType RepositoryPrivileges { get; }
        public RepositoryOriginType RepositoryOriginType { get; }
        public string RepositoryName { get; }

        public async Task<bool> AnyAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AnyAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<int> CountAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task CreateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task CreateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public ValueTask DisposeAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<TEntity?> GetByIdAsync(TKey id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<TEntity?> GetFirstOrDefaultAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<TEntity?> GetSingleOrDefaultAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}