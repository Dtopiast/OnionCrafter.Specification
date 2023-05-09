﻿using OnionCrafter.Base.Entities;
using OnionCrafter.Specification.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionCrafter.Specification
{
    public interface ICompleteRepository<TEntity, TKey> : IWriteRepository<TEntity, TKey>, IReadRepository<TEntity, TKey>
        where TEntity : IEntity<TKey>

    {
    }
}