using ChatApp.Application.Interfaces;
using ChatApp.Persistance.DbContext;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ChatApp.Persistance.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly IFileService _fileService;

        public GenericRepository(ApplicationDbContext context , IFileService fileService)
        {
            this._context = context;
            this._fileService = fileService;
        }
        public async Task AddAsync(T Entity, IFormFile? file = null, string? email = null)
        {
            if(file.Length > 0 && file is not null)
            {
                var filePath  = await _fileService.SaveImageAsync(file, email);
                if(filePath is not null)
                {
                    var getImageProp = Entity.GetType().GetProperty("ImageUrl");
                    getImageProp?.SetValue(Entity, filePath);
                }

            }
            await _context.AddAsync(Entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Set<T>()
                .FirstOrDefaultAsync(e => EF.Property<int>(e, "Id") == id);

            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> Exists(int id)
        {
            var entity = await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(e => EF.Property<int>(e, "Id") == id);
            return entity != null;
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T?> GetById(int id)
        {
           var entity = await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(e => EF.Property<int>(e, "Id") == id);
           return entity;
        }
     

        public async Task UpdateAsync(T Entity)
        {
             _context.Entry(Entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();


        }    
    
    
    }
}
