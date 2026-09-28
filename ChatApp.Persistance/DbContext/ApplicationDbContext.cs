
using System;
using System.Collections.Generic;
using System.Text;
using ChatApp.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace ChatApp.Persistance.DbContext
{
    public class ApplicationDbContext : IdentityDbContext<
     Users,
     IdentityRole<int>,
     int,
     IdentityUserClaim<int>,
     IdentityUserRole<int>,
     IdentityUserLogin<int>,
     IdentityRoleClaim<int>,
     IdentityUserToken<int>>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
    }
}
