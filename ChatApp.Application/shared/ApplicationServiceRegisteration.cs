using ChatApp.Application.mapping;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text;
namespace ChatApp.Application.shared
{
    public static class ApplicationServiceRegisteration
    {
        public static void ConfigureApplicationService(
            this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(typeof(ApplicationServiceRegisteration).Assembly));

            services.AddAutoMapper( cfg => { }, typeof(UserMapping).Assembly);


        }
    }
}
