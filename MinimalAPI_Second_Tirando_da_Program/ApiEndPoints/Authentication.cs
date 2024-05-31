using Microsoft.AspNetCore.Authorization;
using MinimalAPI_Second_Tirando_da_Program.Models;
using MinimalAPI_Second_Tirando_da_Program.Services.Interfaces;

namespace MinimalAPI_Second_Tirando_da_Program.ApiEndPoints
{
    public static class Authentication
    {
        public static void MapAuthenticationEndPoints(this WebApplication app)
        {
            app.MapPost("/Login", [AllowAnonymous] (UserModel usermodel, IServiceToken tokenService) =>
            {
                if (usermodel == null)
                {
                    return Results.BadRequest("Login inválido!");
                }

            if (usermodel.Name == "GBastos" && usermodel.Password == "123456")
            {
                    var tokenString = tokenService.GerarToken(
                        app.Configuration["Jwt:Key"], 
                        app.Configuration["Jwt:Issuer"], 
                        app.Configuration["Jwt:Audience"], usermodel);

                    return Results.Ok(new { token = tokenString });
                }
                else
                {
                    return Results.BadRequest("Login Inválido!");
                }
            }).Produces(StatusCodes.Status400BadRequest)
              .Produces(StatusCodes.Status200OK)
              .WithName("Login")
              .WithTags("Authentication");
        }
    }
}
