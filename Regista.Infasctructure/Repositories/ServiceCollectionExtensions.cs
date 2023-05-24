﻿using Microsoft.Extensions.DependencyInjection;
using Regista.Application.Repositories;
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
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

        }
    }
}
