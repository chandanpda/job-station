using JobStation.Core;
using JobStation.Core.IRepository;
using JobStation.Core.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobStation.API
{
    public static class DIExtension
    {
        public static IServiceCollection AddDatabaseDependency(this IServiceCollection services)
        {
            services.AddTransient<IJobCategoryRepository, JobCategoryRepository>();
            services.AddTransient<ILogInHistoryRepository, LogInHistoryRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IunitOfWork, unitOfWork>();

            return services;
        }
    }
}
