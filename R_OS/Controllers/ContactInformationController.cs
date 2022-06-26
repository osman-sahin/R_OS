using Microsoft.AspNetCore.Mvc;
using R_OS.Business;
using R_OS.Models;
using R_OS.ResponseModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace R_OS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactInformationController : ControllerBase
    {
        private readonly IContactInformationBusiness _contactInformationBusiness;
        public ContactInformationController(IContactInformationBusiness contactInformationBusiness)
        {
            _contactInformationBusiness = contactInformationBusiness;
        }
        // POST api/<ContactInformationController>
        [HttpPost]
        public async Task<ApiResponse<ContactInformation>> Post([FromBody] ContactInformation contactInfo) => await _contactInformationBusiness.CreateAsync(contactInfo);

        // DELETE api/<ContactInformationController>/5
        [HttpDelete("{uuid}")]
        public async Task<ApiResponse<bool>> Delete(Guid uuid) => await _contactInformationBusiness.DeleteAsync(uuid);

    }
}
