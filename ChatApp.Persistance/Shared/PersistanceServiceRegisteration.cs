using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using ChatApp.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using ChatApp.Persistance.DbContext;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
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



            service.AddIdentity<Users, IdentityRole<int>>(opt =>
            {
                opt.Password.RequireLowercase = true;
                opt.SignIn.RequireConfirmedEmail = false;
            })

                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<ApplicationDbContext>();
        }

    }
}
