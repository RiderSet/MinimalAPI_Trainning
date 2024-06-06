using Microsoft.AspNetCore.Mvc;
using MinimalAPI_Second_Tirando_da_Program.AppServiceExtensions;
using MinimalAPI_Second_Tirando_da_Program.Models;
using MinimalAPI_Second_Tirando_da_Program.Repositories.Interfaces;

namespace MinimalAPI_Second_Tirando_da_Program.ApiEndPoints
{
    public static class EndPointAssuntos
    {
        public static void MapAssuntosEndPoint(this WebApplication app)
        {
            var rotaAssuntos = app.MapGroup("Assuntos");

            rotaAssuntos.MapGet("/Assuntos", GetAllAssuntos).WithTags("Assuntos").WithTags("Assuntos").RequireAuthorization();
            rotaAssuntos.MapGet("/Assuntos/{cod:Guid}", GetAssuntoById).WithTags("Assuntos").WithTags("Assuntos").RequireAuthorization();
            rotaAssuntos.MapPost("/Assuntos/", CreateAssunto).WhitValidator<Assunto>().WithTags("Assuntos");
            rotaAssuntos.MapPut("/Assuntos/{codAs:Guid}", UpdateAssunto).WithTags("Assuntos");
            rotaAssuntos.MapPut("/Assuntos/{codAs:Guid}", RemoveAssunto).WithTags("Assuntos");
        }

        internal static async Task<List<Assunto>> GetAllAssuntos([FromServices] IRepositoryAssunto service) 
            => await service.GetAll();

        internal static async Task<Assunto> GetAssuntoById([FromServices] IRepositoryAssunto service, Guid codAs) 
            => await service.GetById(codAs);

        internal static void CreateAssunto([FromServices] IRepositoryAssunto service, [FromBody] Assunto assunto)
            => service.Create(assunto);

        internal static void UpdateAssunto([FromServices] IRepositoryAssunto service, Guid codAs, [FromBody] Assunto assunto) 
            => service.Update(codAs, assunto);

        internal static void RemoveAssunto([FromServices] IRepositoryAssunto service, Guid codAs) 
            => service.Remove(codAs);
    }
}