using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace MyApi 
{
    public class Program
    {
        public static void Main(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseSerilog((context, services, configuration) =>
                {
                    configuration.MinimumLevel.Information()
                        .WriteTo.Console()
                        .WriteTo.File("logs/myapi-log.log", rollingInterval: RollingInterval.Day, outputTemplate: "{Timestamp:o} [{Level:u3}] {Message:lj}{NewLine}{Exception}");
                })
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.ConfigureServices(services => {
                    services.AddHealthChecks();
                    services.AddControllers();
                });

                webBuilder.Configure(app =>
                {               
                    app.UseRouting();
                    app.UseEndpoints(endpoints => { 
                        endpoints.MapHealthChecks("/health");
                        endpoints.MapControllers(); 
                    });
                });
            })
            .Build().Run();
    }
}
