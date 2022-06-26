using R_OS.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace R_OS
{
    public class ServiceBuilder
    {
        internal static ServiceCollection Services;
        public static ServiceCollection Build(string connectionString)
        {
            Services = new ServiceCollection();
            Services.AddDbContext<AddressBookContext>(options =>
                      options.UseNpgsql(connectionString)
                 );
            return Services;
        }
    }
}
