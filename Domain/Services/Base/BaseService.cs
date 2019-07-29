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

        public async virtual Task<TDTO> CreateAsync(TDTO dto)
        {
            TEntity entity = _mapper.Map<TDTO, TEntity>(dto);

            await _repository.AddAsync(entity);

            await _unitOfWork.CompleteAsync();

            return _mapper.Map<TEntity, TDTO>(entity);
        }

        public virtual List<TDTO> GetAll()
        {
            return _mapper.Map<List<TEntity>, List<TDTO>>(_repository.GetAll().ToList());
        }

        public virtual async Task Delete(int id)
        {
            await _repository.Remove(id);
        }
    }
}
