using R_OS.Models;
using R_OS.ResponseModels;
using R_OS.Services;

namespace R_OS.Business
{
    public class ReportBusiness : IReportBusiness
    {
        private readonly IRepository<Report> _service;

        public ReportBusiness(IRepository<Report> service)
        {
            _service = service;
        }
        public async Task<ApiResponse<Report>> CreateAsync()
        {
            Report report = new();
            try
            {
                var result = await _service.Insert(report);

                // Publish to querying service

                return new ApiResponse<Report>(report);

            }
            catch (Exception)
            {
                return new ApiResponse<Report>(resultObject: null, false, 500, "Internal error occured");
                throw;
            }
        }

        public async Task<ApiResponse<IEnumerable<Report>>> GetAllAsync()
        {
            var result = await _service.GetAll();
            return result;
        }

        public async Task<ApiResponse<Report>> GetById(Guid uuid)
        {
            var result = await _service.Get(uuid);
            if (result.ResultObject is null)
                return new ApiResponse<Report>(null, false, 404, "Not Found");
            return new ApiResponse<Report>(result.ResultObject);

        }
    }
}
