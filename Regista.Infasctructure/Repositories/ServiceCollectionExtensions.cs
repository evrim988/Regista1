using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Regista.Application.Repositories;
using Regista.Application.Services.EmailServices;
using Regista.Application.Services.SecurityServices;
using Regista.Infasctructure.Services.EmailServices;
using Regista.Infasctructure.Services.SecurityServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regista.Infasctructure.Repositories
{
    public static class ServiceCollectionExtensions
    {
        public static void MyRepository(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<ISessionService, SessionService>();
            services.AddTransient<IEmailServices, EmailService>();
            services.AddTransient<ISecurityRepository, SecurityRepository>();
        }
    }
}
