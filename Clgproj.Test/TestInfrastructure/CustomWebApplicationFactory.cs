using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Clgproj.Test.TestInfrastructure
{
    internal class CustomWebApplicationFactory : WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                // Remove SQL Server registrations
                services.RemoveAll(typeof(DbContextOptions<WateringDbContext>));
                services.RemoveAll(typeof(DbContextOptions<FertilizerDbContext>));
                services.RemoveAll(typeof(DbContextOptions<InvoiceDbContext>));
                services.RemoveAll(typeof(DbContextOptions<CultivationDbContext>));

                // Replace with InMemory DBs
                services.AddDbContext<WateringDbContext>(o =>
                    o.UseInMemoryDatabase("WateringDb_Test"));

                services.AddDbContext<FertilizerDbContext>(o =>
                    o.UseInMemoryDatabase("FertilizerDb_Test"));

                services.AddDbContext<InvoiceDbContext>(o =>
                    o.UseInMemoryDatabase("InvoiceDb_Test"));

                services.AddDbContext<CultivationDbContext>(o =>
                    o.UseInMemoryDatabase("CultivationDb_Test"));
            });
        }
    }

}