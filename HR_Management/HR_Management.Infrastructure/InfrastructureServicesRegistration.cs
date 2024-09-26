using HR_Management.Application.Contracts.Infrastructure;
using HR_Management.Application.Contracts.Persistence;
using HR_Management.Application.Models;
using HR_Management.Infrastructure.Mail;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR_Management.Infrastructure
{
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection ConfigureInfrastractureServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.Configure<EmailSetting>(configuration.GetSection("EmailSettings"));
            services.AddTransient(typeof(IMailSender), typeof(EmailSender));
           
            return services;
        }
    }
}
