using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace Silky.GatewayHost
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            await CreateHostBuilder(args).Build().RunAsync();
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureSilkyGatewayDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); })
                .UseNacosConfig("NacosConfig", Nacos.YamlParser.YamlConfigurationStringParser.Instance)
            ;
    }
}