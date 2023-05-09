using OnionCrafter.Base.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionCrafter.Specification.Repository.Cache
{
    public class RepositoryContainerOptions : IServiceOptions
    {
        public bool UseLogger { get; set; }
        public bool AutomaticallyRegisterRepositories { get; set; }
    }
}