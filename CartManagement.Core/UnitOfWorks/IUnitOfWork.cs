﻿using CartManagement.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartManagement.Core.UnitOfWorks
{
    public interface IUnitOfWork
    {
        IProductRepository Products { get; }

        ICategoryRepository Categories { get; }

        ICartRepository CartProducts  { get; }

        IPersonRepository Persons  { get; }

        Task CommitAsync();

        void Commit();
    }
}
