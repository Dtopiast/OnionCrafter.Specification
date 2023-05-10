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
        Other = 0,
        Factory,
    }

    public interface IBaseRepository : IDisposable
    {
        public RepositoryPrivilegesType RepositoryPrivileges { get; }
        public RepositoryOriginType RepositoryOriginType { get; }
        public string RepositoryName { get; }
    }
}