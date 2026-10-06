using ChatApp.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatApp.Persistance.Repositories.Services
{
    public class FileService : IFileService
    {
        private readonly string _rootPath;

        public FileService()
        {
            _rootPath = Path.Combine("wwwroot", "files");
            if(!Directory.Exists(_rootPath))
            {
                Directory.CreateDirectory(_rootPath);
            }


        }

        public async Task<bool> DeleteImageAsync(string path)
        {
            string fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", path);
            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
                return true;
            }
            return false;
        }

        public async Task<string> SaveImageAsync(IFormFile file, string email)
        {
            string fileName = file.FileName;
            if(string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentException("File name cannot be null or empty.", nameof(file));
            }
           
            string userFolder = Path.Combine(_rootPath, email);
            Directory.CreateDirectory(userFolder);

            string filePath = Path.Combine(userFolder, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create , FileAccess.Write , FileShare.None))
            {
                await file.CopyToAsync(stream);
            }
            return Path.Combine("files", email, fileName);
        }
    }
}
