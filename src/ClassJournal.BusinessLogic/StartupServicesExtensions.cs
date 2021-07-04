using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ClassJournal.BusinessLogic
{
    public static class StartupServicesExtensions
    {
        public static void AddAuthService(this IServiceCollection services, IConfiguration configuration)
        {
            //services.Configure<AuthOptions>(Configuration);
        }
    }
}