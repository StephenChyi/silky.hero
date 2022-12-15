using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Silky.WorkFlow.EntityFrameworkCore.DbContexts;

namespace Silky.WorkFlowHost
{
    public class ConfigureService : IConfigureService
    {
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSilkySkyApm().AddObjectMapper();

            services.AddDatabaseAccessor(
                options => { options.AddDbPool<DefaultDbContext>(); },
                "Silky.WorkFlow.Database.Migrations");
        }
    }
}
