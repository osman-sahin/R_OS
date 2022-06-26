using R_OS.Models;
using R_OS.ResponseModels;

namespace R_OS.Business
{
    public interface IContactInformationBusiness
    {
        Task<ApiResponse<ContactInformation>> CreateAsync(ContactInformation entity);
        Task<ApiResponse<IEnumerable<ContactInformation>>> GetAllByPersonIdAsync(Guid? parentFK);
        Task<ApiResponse<bool>> DeleteAsync(Guid uuid);
    }
}
