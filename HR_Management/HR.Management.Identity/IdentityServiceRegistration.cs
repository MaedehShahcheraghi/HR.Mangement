using HR.Management.Identity.Models;
using HR.Management.Identity.Service;
using HR_Management.Application.Contracts.Identity;
using HR_Management.Application.Models.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Management.Identity
{
    public static class IdentityServiceRegistration
    {
        public static IServiceCollection ConfigureIdentityService(this IServiceCollection services,
            IConfiguration configuration)
        {

            //AddJwtSetting

            services.Configure<JWTSetting>(configuration.GetSection("JwtSetting"));

            //AddDbContext

            services.AddDbContext<LeaveManagementIdentityDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("LeaveManagementIdentityConnectionString"),
                    b => b.MigrationsAssembly(typeof(LeaveManagementIdentityDbContext).Assembly.FullName));
            });

            //AddIdentity
            services.AddIdentity<ApplicationUser, IdentityRole>().
                AddEntityFrameworkStores<LeaveManagementIdentityDbContext>().AddDefaultTokenProviders();

            //AddDi

            services.AddTransient<IAuthService, AuthService>();

            //AddAuthentication

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidIssuer = configuration["JwtSetting:Issuer"],
                    ValidAudience = configuration["JwtSetting:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSetting:Key"]))
                };
            });


            return services;

        }
    }
}
