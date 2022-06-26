using R_OS.Models;
using R_OS.ResponseModels;
using R_OS.Services;

namespace R_OS.Business
{
    public class ContactInformationBusiness : IContactInformationBusiness
    {
        private readonly IRepository<ContactInformation> _service;

        public ContactInformationBusiness(IRepository<ContactInformation> service)
        {
            _service = service;
        }
        public async Task<ApiResponse<ContactInformation>> CreateAsync(ContactInformation entity)
        {
            try
            {
                await _service.Insert(entity);
                return new ApiResponse<ContactInformation>(entity);

            }
            catch (Exception)
            {
                return new ApiResponse<ContactInformation>(resultObject: null, false, 500, "Internal error occured");
                throw;
            }
        }

        public async Task<ApiResponse<bool>> DeleteAsync(Guid uuid)
        {
            var result = await _service.Get(uuid);
            if (result.ResultObject is null)
            {
                return new ApiResponse<bool>(false, false, 403, "Entity not found");
            }
            try
            {
                await _service.Delete(result.ResultObject);
                return new ApiResponse<bool>(true);

            }
            catch (Exception)
            {
                return new ApiResponse<bool>(false, false, 500, "Internal error occured");
                throw;
            }
        }

        public async Task<ApiResponse<IEnumerable<ContactInformation>>> GetAllByPersonIdAsync(Guid? personId)
        {
            var result = await _service.GetAll();
            return result;
        }
    }
}
