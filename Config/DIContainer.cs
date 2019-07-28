using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestGAP.Domain.Services;
using TestGAP.Domain.Services.Interfaces;
using TestGAP.Infrastructure.Repositories;
using TestGAP.Infrastructure.Repositories.Interfaces;

namespace TestGAP.Config
{
    public class DIContainer
    {
        public static void Register(IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            #region [REPOSITORIES]
            services.AddScoped<ICoverageTypeRepository, CoverageTypeRepository>();
            services.AddScoped<IRiskTypeRepository, RiskTypeRepository>();
            #endregion

            #region [SERVICES]
            services.AddScoped<IRiskTypeService, RiskTypeService>();
            #endregion
        }
    }
}
