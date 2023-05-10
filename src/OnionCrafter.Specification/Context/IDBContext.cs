using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using OnionCrafter.Base.Entities;

namespace OnionCrafter.Specification.Context
{
    public interface IDBContext : IBaseContext, IDisposable
    {
    }
}