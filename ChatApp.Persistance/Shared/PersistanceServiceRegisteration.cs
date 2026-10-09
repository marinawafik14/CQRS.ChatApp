using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using ChatApp.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using ChatApp.Persistance.DbContext;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using ChatApp.Application.Interfaces;
using ChatApp.Persistance.Repositories.Services;
using ChatApp.Persistance.Repositories;
namespace ChatApp.Persistance.Shared
{
    public static class PersistanceServiceRegisteration
    {

        public static void ConfigureServicePersistance (this IServiceCollection service , IConfiguration configuration)
        {
            service.AddDbContext<ApplicationDbContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("cqrs-chatAppConnection"));
            });



            service.AddIdentity<User, IdentityRole<int>>(opt =>
            {
                opt.Password.RequireLowercase = true;
                opt.SignIn.RequireConfirmedEmail = false;
            })

                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            service.AddScoped<IFileService, FileService>();
            service.AddScoped(serviceType: typeof(IGenericRepository<>), implementationType: typeof(GenericRepository<>));
        }

    }
}
