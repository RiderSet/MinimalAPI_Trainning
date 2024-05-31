using Microsoft.EntityFrameworkCore;
using MinimalAPI_Second_Tirando_da_Program.AppServiceExtensions;
using MinimalAPI_Second_Tirando_da_Program.Context;
using MinimalAPI_Second_Tirando_da_Program.Models;

namespace MinimalAPI_Second_Tirando_da_Program.ApiEndPoints
{
    public static class EndPointLivros
    {
        public static void MapLivrosEndPoint(this WebApplication app)
        {
            //===============================
            app.MapPost("/Livros/", async (Livro livro, CTX contexto) =>
            {
                contexto.Livros.Add(livro);
                await contexto.SaveChangesAsync();

                return Results.Created($"/Livros/{livro.Codl}", livro);
            }).WhitValidator<Livro>().WithTags("Livros");
            //===============================
            app.MapGet("/Livros", async (CTX contexto) => await contexto.Livros.ToListAsync())
            .WithTags("Livros")
            .RequireAuthorization();
            //===============================
            app.MapGet("/Livros/{codl:Guid}", async (Guid codl, CTX contexto) =>
            {
                return await contexto.Livros.FindAsync(codl) is Livro livro ? Results.Ok(livro) : Results.NotFound();
            })
            .WithTags("Livros");
            //===============================
            app.MapPut("/Livros/{codl:Guid}", async (Guid codAs, Livro livro, CTX contexto) =>
            {
                if (livro.CodAs != codAs)
                {
                    return Results.BadRequest();
                }
                var livroDb = await contexto.Livros.FindAsync(codAs);
                if (livroDb is null) return Results.NotFound();

                livroDb.Titulo = livro.Titulo;
                livroDb.Editora = livro.Editora;
                livroDb.Edicao = livro.Edicao;
                livroDb.Image_Address = livro.Image_Address;
                livroDb.AnoPublicacao = livro.AnoPublicacao;
                livroDb.Assunto = livro.Assunto;
                livroDb.Autores = livro.Autores;

                await contexto.SaveChangesAsync();
                return Results.Ok(livroDb);
            }).WithTags("Livros");
            //===============================
            app.MapPut("/Livros/{codl:Guid}", async (Guid codAs, CTX contexto) =>
            {
                var livro = await contexto.Livros.FindAsync(codAs);
                if (livro is not null)
                {
                    contexto.Livros.Remove(livro);
                    await contexto.SaveChangesAsync();
                }
                return Results.NoContent();
            }).WithTags("Livros");
            //===============================

        }
    }
}