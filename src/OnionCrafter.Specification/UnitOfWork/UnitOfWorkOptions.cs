using OnionCrafter.Base.Services;

namespace OnionCrafter.Specification.UnitOfWork
{
    //IServiceOptions debe de tener tipado
    public class UnitOfWorkOptions : IServiceOptions
    {
        public bool UseLogger { get; set; }
        public bool AutomaticallyRegisterRepositories { get; set; }
        public string? RollbackMessageLogger { get; set; }
        public string? CommitMessageLogger { get; set; }
        public string? BeginMessageLogger { get; set; }
    }
}