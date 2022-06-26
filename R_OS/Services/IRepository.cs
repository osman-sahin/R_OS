using Microsoft.EntityFrameworkCore;
using R_OS.Context;
using R_OS.Models;
using R_OS.ResponseModels;

namespace R_OS.Services
{
    public interface IRepository<T> where T : BaseModel
    {
        Task<ApiResponse<IEnumerable<T>>> GetAll();
        Task<ApiResponse<T>> Get(Guid uuid);
        Task<ApiResponse<T>> Insert(T entity);
        Task<ApiResponse<bool>> Delete(T entity);
    }
    public class Repository<T> : IRepository<T> where T : BaseModel
    {
        private readonly AddressBookContext _context;
        private DbSet<T> _entities;
        public Repository(AddressBookContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }
        public virtual async Task<ApiResponse<IEnumerable<T>>> GetAll()
        {
            var result = await _entities.ToListAsync();
            if (result == null)
                return new ApiResponse<IEnumerable<T>>(null, false, 404, "Not Found");
            return new ApiResponse<IEnumerable<T>>(result);

        }
        public virtual async Task<ApiResponse<T>> Get(Guid uuid)
        {
            var result = await _entities.SingleOrDefaultAsync(s => s.UUID == uuid);
            if (result == null)
                return new ApiResponse<T>(null, false, 404, "Not Found");
            return new ApiResponse<T>(result);
        }


        public virtual async Task<ApiResponse<T>> Insert(T entity)
        {
            try
            {
                await _entities.AddAsync(entity);
                await _context.SaveChangesAsync();
                return new ApiResponse<T>(entity);
            }
            catch (Exception)
            {
                return new ApiResponse<T>(null, false, 500, "Internal error occured");
            }

        }
        public virtual async Task<ApiResponse<bool>> Delete(T entity)
        {
            if (IsExist(entity.UUID).Result)
            {
                try
                {
                    _entities.Remove(entity);
                    await _context.SaveChangesAsync();
                    return new ApiResponse<bool>(true);
                }
                catch (Exception)
                {
                    return new ApiResponse<bool>(false, false, 500, "Internal error occured");
                }
            }
            return new ApiResponse<bool>(false, false, 500, "Entity not found");
        }

        private async Task<bool> IsExist(Guid uuid)
        {
            var result = await _entities.SingleOrDefaultAsync(s => s.UUID == uuid);
            if (result == null)
                return false;
            return true;
        }
    }
}
