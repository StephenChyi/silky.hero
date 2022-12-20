using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace Silky.OrganizationHost
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            await CreateHostBuilder(args).Build().RunAsync();
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureSilkyGeneralHostDefaults()
                .UseNacosConfig("NacosConfig", Nacos.YamlParser.YamlConfigurationStringParser.Instance)
            ;
    }
}