using MassTransit;
using R_OS.Models;
using R_OS.ResponseModels;
using R_OS.Services;

namespace R_OS.Business
{
    public class ReportBusiness : IReportBusiness
    {
        private readonly IRepository<Report> _service;
        private readonly IPublishEndpoint _publishEndpoint;

        public ReportBusiness(IRepository<Report> service, IPublishEndpoint publishEndpoint)
        {
            _service = service;
            _publishEndpoint = publishEndpoint;
        }
        public async Task<ApiResponse<Report>> CreateAsync()
        {
            Report report = new();
            try
            {
                var result = await _service.Insert(report);
                if (result.ResultObject is not null)
                    await _publishEndpoint.Publish(new ReportQueueModel
                    {
                        ReportUUID = result.ResultObject.UUID
                    }); ;

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
