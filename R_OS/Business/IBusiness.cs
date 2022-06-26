using R_OS.ResponseModels;

namespace R_OS.Business
{
    public interface IBusiness<T> where T : class
    {
        Task<ApiResponse<T>> CreateAsync(T entity);
        Task<ApiResponse<IEnumerable<T>>> GetAllAsync();
    }
}
