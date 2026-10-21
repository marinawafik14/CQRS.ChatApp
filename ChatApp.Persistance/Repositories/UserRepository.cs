using ChatApp.Application.Interfaces;
using ChatApp.Domain.Entities;
using ChatApp.Persistance.DbContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatApp.Persistance.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context, IFileService fileService) : base(context, fileService)
        {
        }
    }
}
