using Microsoft.Extensions.DependencyInjection;
using MinimalAPI_Second_Tirando_da_Program.Context;
using MinimalAPI_Second_Tirando_da_Program.Models;

namespace MinimalAPI_Test;

    public class Minimal_MockData
    {
        public static async Task CreateAssuntos(MinimalAPI_Application app, bool criar)
        {
            using (var scope = app.Services.CreateScope())
            {
                var provider = scope.ServiceProvider;
                using (var ctx = provider.GetRequiredService<CTX>())
                {
                    await ctx.Database.EnsureCreatedAsync();
                    if (criar)
                    {
                        await ctx.Assuntos.AddRangeAsync(new Assunto("Faroeste"));
                        await ctx.Assuntos.AddRangeAsync(new Assunto("Romance"));

                        await ctx.SaveChangesAsync();
                    }
                }
            }
        }
    }
