using OnionCrafter.Base.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionCrafter.Specification
{
    public interface IWriteRepository<TEntity, TKey> : IBaseRepository<TEntity> where TEntity : IEntity<TKey>
    {
    }
}