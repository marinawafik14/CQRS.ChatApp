
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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
        public DbSet<Message> Messages { get; set; }
        public DbSet<BlockedUser> BlockedUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityUserLogin<int>>().HasKey(l => new { l.LoginProvider, l.ProviderKey });
            builder.Entity<IdentityUserRole<int>>().HasKey(l => new { l.UserId, l.RoleId });
            builder.Entity<IdentityUserToken<int>>().HasKey(l => new { l.UserId, l.LoginProvider, l.Name });


            builder.Entity<Message>()
                .HasOne(m => m.Sender)
                .WithMany(u => u.SentMessages)
                .HasForeignKey(m => m.SenderId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.Entity<BlockedUser>()
               .HasOne(m => m.Blocker)
               .WithMany()
               .HasForeignKey(m => m.BlockerId)
               .OnDelete(DeleteBehavior.Restrict);


            builder.Entity<BlockedUser>()
               .HasOne(m => m.Blocked)
               .WithMany()
               .HasForeignKey(m => m.BlockedId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
