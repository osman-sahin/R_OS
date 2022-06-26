using R_OS.Models;
using R_OS.ResponseModels;

namespace R_OS.Business
{
    public interface IPeopleBusiness
    {
        Task<ApiResponse<Person>> CreateAsync(Person entity);
        Task<ApiResponse<IEnumerable<Person>>> GetAllAsync();
        Task<ApiResponse<Person>> GetById(Guid uuid);
        Task<ApiResponse<bool>> DeleteAsync(Guid uuid);
    }
}
