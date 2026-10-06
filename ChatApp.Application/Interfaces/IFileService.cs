using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatApp.Application.Interfaces
{
    public interface IFileService 
    {

        public Task<string> SaveImageAsync(IFormFile file, string email);
        public Task<bool> DeleteImageAsync(string Path);

    }
}
