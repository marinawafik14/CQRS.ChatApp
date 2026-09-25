using Microsoft.Extensions.DependencyInjection;
using System;
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
        }
    }
}
