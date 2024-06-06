using MinimalAPI_Second_Tirando_da_Program.Models;

namespace MinimalAPI_Second_Tirando_da_Program.Repositories.Interfaces
{
    public interface IRepositoryToken
    {
        string GerarToken(string key, string issuer, string audience, UserModel user);
    }
}
