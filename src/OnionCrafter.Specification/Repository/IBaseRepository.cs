using OnionCrafter.Base.Services;

namespace OnionCrafter.Specification.Repository
{
    public enum RepositoryPrivilegesType
    {
        None = 0,
        Write,
        Read,
        Complete
    }

    public enum RepositoryOriginType
    {
        Database,
        File,
        Memory,
        Api,
    }

    public interface IBaseRepository : IService<RepositoryOptions>, IAsyncDisposable
    {
        public RepositoryPrivilegesType RepositoryPrivileges { get; }
        public RepositoryOriginType RepositoryOrigin { get; }
        public string RepositoryName { get; }
    }
}