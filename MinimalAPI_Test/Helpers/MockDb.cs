using Microsoft.EntityFrameworkCore;
using MinimalAPI_Second_Tirando_da_Program.Context;

namespace MinimalAPI_Test.Helpers
{
    public class MockDb : IDbContextFactory<CTX>
    {
        public CTX CreateDbContext()
        {
            var options = new DbContextOptionsBuilder<CTX>()
            .UseInMemoryDatabase($"InMemoryTestDb-{DateTime.Now.ToFileTimeUtc()}").Options;

            return new CTX(options);
        }
    }
}
