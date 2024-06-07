using MinimalAPI_Second_Tirando_da_Program.Models;
using MinimalAPI_Second_Tirando_da_Program.Repositories.Interfaces;
using MinimalAPI_Second_Tirando_da_Program.Services.Interfaces;

namespace MinimalAPI_Second_Tirando_da_Program.Services
{
    public class ServiceAssunto : IServiceAssunto
    {
        private readonly IRepositoryAssunto repository;

        public ServiceAssunto(IRepositoryAssunto _repository)
        {
            repository = _repository;
        }

        public Task<List<Assunto>> GetAll()
        {
            return repository.GetAll();
        }

        public Task<Assunto> GetById(Guid cod)
        {
            return repository.GetById(cod);
        }

        public Task<IResult> Create(Assunto assunto)
        {
            return repository.Create(assunto);
        }

        public Task<IResult> Remove(Guid cod)
        {
            return repository.Remove(cod);
        }

        public Task<IResult> Update(Guid cod, Assunto assunto)
        {
            return repository.Update(cod, assunto);
        }
    }
}