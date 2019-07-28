using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestGAP.Domain.Services.Interfaces
{
    public interface IBaseService<TDTO> where TDTO : class
    {
        Task<TDTO> CreateAsync(TDTO dto);
        List<TDTO> GetAll();
    }
}
