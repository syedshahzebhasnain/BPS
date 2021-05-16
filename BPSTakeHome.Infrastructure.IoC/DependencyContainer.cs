using Microsoft.Extensions.DependencyInjection;
using BPSTakeHome.Infrastructure;
using System;
using BPSTakeHome.Domain.Interfaces;
using BPSTakeHome.Application.Services;
using BPSTakeHome.Application.Interfaces;

namespace BPSTakeHome.Infrastructure.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //CleanArchitecture.Application
            services.AddScoped<IEmployeeService, EmployeeService>();

            //CleanArchitecture.Domain.Interfaces | CleanArchitecture.Infra.Data.Repositories
            services.AddScoped<IEmployeeRepository, IEmployeeRepository>();
        }

    }
}
