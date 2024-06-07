using Microsoft.EntityFrameworkCore;
using MinimalAPI_Second_Tirando_da_Program.Context;
using MinimalAPI_Second_Tirando_da_Program.Models;
using MinimalAPI_Second_Tirando_da_Program.Repositories.Interfaces;

namespace MinimalAPI_Second_Tirando_da_Program.Repositories
{
    public class RepositoryAssunto : IRepositoryAssunto
    {
        private readonly CTX contexto;

        public RepositoryAssunto(CTX _contexto)
        {
            contexto = _contexto;
        }

        public async Task<List<Assunto>> GetAll()
        {
            return await contexto.Assuntos.ToListAsync();
        }

        public async Task<Assunto> GetById(Guid cod)
        {
            var assunto = await contexto.Assuntos.FirstOrDefaultAsync(x => x.CodAs == cod);
            if (assunto is null)
            {
                return null;
            }
            return assunto;
        }

        public async Task<IResult> Create(Assunto assunto)
        {
                  contexto.Assuntos.Add(assunto);
            await contexto.SaveChangesAsync();

            return Results.Created($"/save/{assunto.CodAs}", assunto);
        }

        public async Task<IResult> Update(Guid cod, Assunto assunto)
        {
            if (assunto.CodAs != cod)
            {
                return Results.BadRequest();
            }

            var assuntoDb = await contexto.Assuntos.FindAsync(cod);
            if (assuntoDb is null) return Results.NotFound();

            assuntoDb.Descricao = assunto.Descricao;
            assuntoDb.Livros = assunto.Livros;

            await contexto.SaveChangesAsync();
            return Results.Ok(assuntoDb);
        }

        public async Task<IResult> Remove(Guid cod)
        {
            var assunto = await contexto.Assuntos.FindAsync(cod);

            if (assunto.CodAs != cod)
            {
                return Results.BadRequest();
            }
            contexto.Remove(assunto);

            await contexto.SaveChangesAsync();
            return Results.Ok(assunto);
        }
    }
}
