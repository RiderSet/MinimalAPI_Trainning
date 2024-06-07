using Microsoft.EntityFrameworkCore;
using MinimalAPI_Second_Tirando_da_Program.AppServiceExtensions;
using MinimalAPI_Second_Tirando_da_Program.Context;
using MinimalAPI_Second_Tirando_da_Program.Models;

namespace MinimalAPI_Second_Tirando_da_Program.ApiEndPoints
{
    public static class EndPointAutores
    {
        public static void MapAutoresEndPoint(this WebApplication app)
        {
            //===============================
            app.MapPost("/Autores/", async (Autor autor, CTX contexto) =>
            {
                contexto.Autores.Add(autor);
                await contexto.SaveChangesAsync();

                return Results.Created($"/Autores/{autor.CodAu}", autor);
            }).WithTags("Autores");
        //}).WhitValidator<Autor>().WithTags("Autores");
        //===============================
        app.MapGet("/Autores", async (CTX contexto) => await contexto.Autores.ToListAsync())
            .WithTags("Autores")
            .RequireAuthorization();
            //===============================
            app.MapGet("/Autores/{codAu:Guid}", async (Guid codAu, CTX contexto) =>
            {
                return await contexto.Autores.FindAsync() is Autor autor ? Results.Ok(autor) : Results.NotFound();
            })
            .WithTags("Autores")
            .RequireAuthorization();
            //===============================
            app.MapPut("/Autores/{codAu:Guid}", async (Guid codAu, Autor autor, CTX contexto) =>
            {
                if (autor.CodAu != codAu)
                {
                    return Results.BadRequest();
                }
                var autorDb = await contexto.Autores.FindAsync(codAu);
                if (autorDb is null) return Results.NotFound();

                autorDb.Nome = autor.Nome;
                autorDb.Livros = autor.Livros;
                autorDb.Assuntos = autor.Assuntos;

                await contexto.SaveChangesAsync();
                return Results.Ok(autorDb);
            }).WithTags("Autores");
            //===============================
            app.MapPut("/Autores/{codAu:Guid}", async (Guid codAu, CTX contexto) =>
            {
                var autor = await contexto.Autores.FindAsync(codAu);
                if (autor is not null)
                {
                    contexto.Autores.Remove(autor);
                    await contexto.SaveChangesAsync();
                }
                return Results.NoContent();
            }).WithTags("Autores");
            //===============================

        }
    }
}