using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnionCrafter;
using OnionCrafter.Base.Entities;

namespace OnionCrafter.Specification
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