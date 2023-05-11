using OnionCrafter.Base.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionCrafter.Specification.Repository
{
    public class RepositoryOptions : IServiceOptions
    {
        public RepositoryPrivilegesType RepositoryPrivileges { get; }
        public RepositoryOriginType RepositoryOrigin { get; }
        public string? RepositoryName { get; }
    }
}