using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using R_OS.Context;
using R_OS.Models;
using R_OS.ResponseModels;

namespace R_OS.Services
{
    public interface IPersonRepository : IRepository<Person>
    {
        Task<ApiResponse<Person>> GetWithContactInfos(Guid uuid);
    }

    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        private readonly AddressBookContext _context;
        public PersonRepository(AddressBookContext context)
          : base(context)
        {
            _context = context;
        }

        public async Task<ApiResponse<Person>> GetWithContactInfos(Guid uuid)
        {
            var result = await _context.People
                    .Where(x => x.UUID == uuid).Include(x => x.ContactInfo)
                    .Select(x => new Person
                    {
                        Name = x.Name,
                        Surname = x.Surname,
                        Company = x.Company,
                        CreatedOn = x.CreatedOn,
                        UUID = x.UUID,
                        ContactInfo = x.ContactInfo
                    }).FirstOrDefaultAsync();

            if (result == null)
                return new ApiResponse<Person>(null, false, 404, "Not Found");
            return new ApiResponse<Person>(result);
        }
    }
}
