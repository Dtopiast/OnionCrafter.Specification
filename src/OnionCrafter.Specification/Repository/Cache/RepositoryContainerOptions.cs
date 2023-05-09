using OnionCrafter.Base.Services;

namespace OnionCrafter.Specification.Repository.Cache
{
    public class RepositoryContainerOptions : IServiceOptions
    {
        public bool UseLogger { get; set; }
        public bool AutomaticallyRegisterRepositories { get; set; }
    }
}