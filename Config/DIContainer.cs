using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestGAP.Infrastructure.Repositories;
using TestGAP.Infrastructure.Repositories.Interfaces;

namespace TestGAP.Config
{
    public class DIContainer
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            #region [REPOSITORIES]
            services.AddScoped<ICoverageTypeRepository, CoverageTypeRepository>();
            #endregion
        }
    }
}
