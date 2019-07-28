using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestGAP.Domain.Services.Interfaces;
using TestGAP.Infrastructure.Repositories.Base;
using TestGAP.Infrastructure.Repositories.Interfaces;

namespace TestGAP.Domain.Services.Base
{
    public abstract class BaseService<TDTO, TEntity> : IBaseService<TDTO>
        where TDTO : class
        where TEntity : class
    {
        public IBaseRepository<TEntity> _repository;
        public IMapper _mapper;
        public IUnitOfWork _unitOfWork;

        public BaseService(IBaseRepository<TEntity> repository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async virtual Task CreateAsync(TDTO dto)
        {

            TEntity entity = _mapper.Map<TDTO, TEntity>(dto);

            await _repository.AddAsync(entity);

            //return _mapper.Map<TDTO>(entity);
        }


    }
}
