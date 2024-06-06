using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using MinimalAPI_Second_Tirando_da_Program.Context;

namespace MinimalAPI_Test;

public class MinimalAPI_Application : WebApplicationFactory<Program>
{

    protected override IHost CreateHost(IHostBuilder builder)
    {
        var root = new InMemoryDatabaseRoot();
        builder.ConfigureServices(services =>
        {
            services.RemoveAll(typeof(DbContextOptions<CTX>));
            services.AddDbContext<CTX>(options =>
                options.UseInMemoryDatabase("GBastos.Minimal", root));
        });
        return base.CreateHost(builder);
    }
}
