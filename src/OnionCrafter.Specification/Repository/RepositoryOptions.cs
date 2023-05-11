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
        public RepositoryPrivilegesType SetRepositoryPrivileges { get; set; }
        public RepositoryOriginType SetRepositoryOrigin { get; set; }
        public string? SetRepositoryName { get; set; }
    }
}