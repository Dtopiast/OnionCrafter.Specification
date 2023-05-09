namespace OnionCrafter.Specification.Repository
{
    public enum RepositoryPrivilegesType
    {
        None = 0,
        Write,
        Read,
        Complete
    }
    public interface IBaseRepository : IDisposable
    {
        public RepositoryPrivilegesType RepositoryPrivileges { get; }
    }
}