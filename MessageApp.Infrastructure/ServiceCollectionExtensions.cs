using MessageApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MessageApp.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDataAccessServices(this IServiceCollection services, string connesctionString)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connesctionString));
        }
    }
}
