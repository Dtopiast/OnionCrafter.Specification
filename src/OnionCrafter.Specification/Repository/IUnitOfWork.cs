﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionCrafter.Specification.Repository
{
    public interface IUnitOfWork
    {
        Task<int> CommitAsync();
    }

    public interface IUnitOfWork<TDBContext> : IUnitOfWork
    {
        Task RollbackAsync();

        Task BeginAsync();
    }
}