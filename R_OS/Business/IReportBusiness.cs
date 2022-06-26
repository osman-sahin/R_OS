using R_OS.Models;
using R_OS.ResponseModels;

namespace R_OS.Business
{
    public interface IReportBusiness
    {
        Task<ApiResponse<Report>> CreateAsync();
        Task<ApiResponse<IEnumerable<Report>>> GetAllAsync();
        Task<ApiResponse<Report>> GetById(Guid uuid);
    }
}
