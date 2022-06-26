using Microsoft.AspNetCore.Mvc;
using R_OS.Business;
using R_OS.Models;
using R_OS.ResponseModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace R_OS.Controllers
{
    [Route("api/v1/people")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IPeopleBusiness _peopleBusiness;
        public PeopleController(IPeopleBusiness peopleBusiness)
        {
            _peopleBusiness = peopleBusiness;
        }
        // GET: api/<PeopleController>
        [HttpGet]
        public async Task<ApiResponse<IEnumerable<Person>>> Get() => await _peopleBusiness.GetAllAsync();

        // GET: api/<PeopleController>/5
        [HttpGet("{uuid}")]
        public async Task<ApiResponse<Person>> Get(Guid uuid) => await _peopleBusiness.GetById(uuid);

        // POST: api/<PeopleController>
        [HttpPost]
        public async Task<ApiResponse<Person>> Post([FromBody] Person person) => await _peopleBusiness.CreateAsync(person);

        // DELETE: api/<PeopleController>/5
        [HttpDelete("{uuid}")]
        public async Task<ApiResponse<bool>> Delete(Guid uuid) => await _peopleBusiness.DeleteAsync(uuid);
    }
}
