using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using ChatApp.Domain.Entities



using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using ChatApp.Persistance.DbContext;
namespace ChatApp.Persistance.Shared
{
    public static class PersistanceServiceRegisteration
    {

        public static void ConfigureServicePersistance (this IServiceCollection service)
        {
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
