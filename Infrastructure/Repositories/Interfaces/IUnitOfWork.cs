﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestGAP.Infrastructure.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
