using Microsoft.EntityFrameworkCore;
using R_OS.Models;

namespace R_OS.Context
{
    public class AddressBookContext : DbContext
    {
        public AddressBookContext(DbContextOptions<AddressBookContext> options) : base(options)
        {

        }

        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<ContactInformation> ContactInfos { get; set; }
        public virtual DbSet<Report> Reports { get; set; }


    }
}
