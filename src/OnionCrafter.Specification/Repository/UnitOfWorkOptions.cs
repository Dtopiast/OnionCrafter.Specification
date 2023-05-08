using OnionCrafter.Base.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionCrafter.Specification.Repository
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