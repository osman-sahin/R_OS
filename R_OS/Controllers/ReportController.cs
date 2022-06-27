using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using R_OS.Business;
using R_OS.Models;
using R_OS.ResponseModels;

namespace R_OS.Controllers
{
    [Route("api/v1/report")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportBusiness _reportBusiness;
        public ReportController(IReportBusiness reportBusiness)
        {
            _reportBusiness = reportBusiness;
        }

        // GET: api/<ReportController>
        [HttpGet]
        public async Task<ApiResponse<IEnumerable<Report>>> Get() => await _reportBusiness.GetAllAsync();

        // GET: api/<ReportController>/5
        [HttpGet("{uuid}")]
        public async Task<ApiResponse<Report>> Get(Guid uuid) => await _reportBusiness.GetById(uuid);

        // POST api/<ReportController>
        [HttpPost]
        public async Task<ApiResponse<Report>> Post() => await _reportBusiness.CreateAsync();


    }
}
