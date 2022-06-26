using R_OS.Models;
using R_OS.ResponseModels;
using R_OS.Services;

namespace R_OS.Business
{
    public class PeopleBusiness : IPeopleBusiness
    {
        private readonly IPersonRepository _service;

        public PeopleBusiness(IPersonRepository service)
        {
            _service = service;
        }

        public async Task<ApiResponse<IEnumerable<Person>>> GetAllAsync()
        {
            var result = await _service.GetAll();
            return result;
        }

        public async Task<ApiResponse<Person>> GetById(Guid uuid)
        {
            var result = await _service.GetWithContactInfos(uuid);
            if (result.ResultObject is null)
                return new ApiResponse<Person>(null, false, 404, "Not Found");
            return new ApiResponse<Person>(result.ResultObject);

        }

        public async Task<ApiResponse<Person>> CreateAsync(Person entity)
        {
            try
            {
                await _service.Insert(entity);
                return new ApiResponse<Person>(entity);
            }
            catch (Exception)
            {
                return new ApiResponse<Person>(resultObject: null, false, 500, "Internal error occured");
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
    }
}
