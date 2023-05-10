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
    }

    public enum RepositoryCreationType
    {
        Other = 0,
        Factory,
    }

    public interface IBaseRepository : IAsyncDisposable
    {
        public RepositoryPrivilegesType RepositoryPrivileges { get; }
        public RepositoryOriginType RepositoryOrigin { get; }
        public string RepositoryName { get; }
    }
}