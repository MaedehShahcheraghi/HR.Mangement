using HR_Management.Application.Contracts.Persistence;
using HR_Management.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR_Management.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static  IServiceCollection ConfigurePersistenceServices(this IServiceCollection services,IConfiguration configuration) {
            services.AddDbContext<LeaveManagementDbContext>(options =>
            {
                options.UseSqlServer(configuration
                    .GetConnectionString("LeaveManagementConnectionString"), b => b.MigrationsAssembly(typeof(LeaveManagementDbContext).Assembly.FullName));
            });
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(ILeaveAllocationRepository), typeof(LeaveAlocationRepository));
            services.AddScoped(typeof(ILeaveRequestRepository), typeof(LeaveRequestRepository));
            services.AddScoped(typeof(ILeaveTypeRepository), typeof(LeaveTypeRepository));
          
        

            return services;
        }
    }
}
