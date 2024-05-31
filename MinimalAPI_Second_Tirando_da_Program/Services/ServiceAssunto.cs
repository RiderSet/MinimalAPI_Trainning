using Microsoft.EntityFrameworkCore;
using MinimalAPI_Second_Tirando_da_Program.Context;
using MinimalAPI_Second_Tirando_da_Program.Models;
using MinimalAPI_Second_Tirando_da_Program.Services.Interfaces;

namespace MinimalAPI_Second_Tirando_da_Program.Services
{
    public class ServiceAssunto : IServiceAssunto
    {
        private readonly CTX contexto;

        public ServiceAssunto(CTX _contexto)
        {
            contexto = _contexto;
        }

        public async Task<List<Assunto>> GetAll()
        {
            var assuntos = await contexto.Assuntos.ToListAsync();
            return assuntos;
        }

        public async Task<Assunto> GetById(Guid codas)
        {
            var assunto = await contexto.Assuntos.FirstOrDefaultAsync(x => x.CodAs == codas);
            if (assunto is null)
            {
                return null;
            }
            return assunto;
        }

        public IResult Create(Assunto assunto)
        {
            contexto.Add(assunto);
            return Results.Created($"/Assuntos/{assunto.CodAs}", assunto);
        }

        public async Task<IResult> Update(Guid codAs, Assunto assunto)
        {
            if (assunto.CodAs != codAs)
            {
                return Results.BadRequest();
            }

            var assuntoDb = await contexto.Assuntos.FindAsync(codAs);
            if (assuntoDb is null) return Results.NotFound();

            assuntoDb.Descricao = assunto.Descricao;
            assuntoDb.Livros = assunto.Livros;

            await contexto.SaveChangesAsync();
            return Results.Ok(assuntoDb);
        }

        //public async Task<IResult> Create(Assunto assunto, IValidator<Assunto> validator)
        //{
        //    var validate = await validator.ValidateAsync(assunto);
        //    if (!validate.IsValid)
        //    {
        //        return Results.BadRequest(validate.Errors);
        //    }
        //    contexto.Add(assunto);
        //    return Results.Created($"/Assuntos/{assunto.CodAs}", assunto);
        //}

        public async Task<IResult> Remove(Guid codAs)
        {
            var assunto = await contexto.Assuntos.FindAsync(codAs);
            if (assunto is not null)
            {
                contexto.Assuntos.Remove(assunto);
                await contexto.SaveChangesAsync();
            }
            return Results.NoContent();
        }
    }
}