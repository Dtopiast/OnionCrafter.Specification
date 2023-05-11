using OnionCrafter.Base.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionCrafter.Specification.Context.Cache
{
    public interface IContextContainer : IService, IAsyncDisposable
    {
    }
}