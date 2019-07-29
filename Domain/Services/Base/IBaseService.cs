using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestGAP.Domain.Services.Base
{
    public interface IBaseService<TDTO> where TDTO : class
    {
        Task<TDTO> GetById(int id);
        Task<TDTO> CreateAsync(TDTO dto);
        List<TDTO> GetAll();
        Task Delete(int id);
    }
}
