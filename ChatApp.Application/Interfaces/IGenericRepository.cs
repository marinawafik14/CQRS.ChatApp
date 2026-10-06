using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
namespace ChatApp.Application.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {

        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T?> GetById(int id);
        Task<bool> Exists(int id);
        Task AddAsync(T Entity, IFormFile? file = default, string? email = default);
        Task UpdateAsync(T Entity);
        Task DeleteAsync (int id);


    }
}
