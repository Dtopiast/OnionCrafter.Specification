using OnionCrafter.Base.Entities;
using OnionCrafter.Specification.Context;
using System.Text;

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

        protected string CreateRepositoryName(string? name = null)
        {
            List<string> names = new List<string>() { "Repository", "repository" };
            var builder = new StringBuilder();
            builder.Append(name ?? nameof(TEntity));
            foreach (var item in names)
            {
                if (builder.ToString().Contains(item))
                {
                    builder.Replace(item, null);
                    break;
                }
            }
            switch (RepositoryPrivileges)
            {
                case RepositoryPrivilegesType.Write:
                    builder.Append("-Write");
                    break;

                case RepositoryPrivilegesType.Read:
                    builder.Append("-Read");
                    break;

                case RepositoryPrivilegesType.Complete:
                    builder.Append("-Complete");
                    break;

                default:
                    break;
            }
            builder.Append("Repository");
            return builder.ToString();
        }

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