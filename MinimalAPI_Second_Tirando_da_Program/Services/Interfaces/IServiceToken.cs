using MinimalAPI_Second_Tirando_da_Program.Models;

namespace MinimalAPI_Second_Tirando_da_Program.Services.Interfaces
{
    public interface IServiceToken
    {
        string GerarToken(string key, string issuer, string audience, UserModel user);
    }
}
