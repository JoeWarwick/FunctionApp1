using FunctionApp1.Data;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Linq;

[assembly: FunctionsStartup(typeof(FunctionApp1.Startup))]
namespace FunctionApp1
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddDbContext<TestContext>(options => { 
                options.UseSqlite("Data Source=.\\Data\\employees.db");
                options.UseLoggerFactory(LoggerFactory.Create(builder => { builder.AddConsole(); }));
            });

            var app = builder.Services.BuildServiceProvider();

            using (var seedScope = app.CreateScope())
            {
                var context = seedScope.ServiceProvider.GetRequiredService<TestContext>();
                if (!context.Employee.Any())
                {
                    DataInitialiser.SeedData(context).Wait();
                }
            }
        }
    }
}
