using MinimalAPI_Second_Tirando_da_Program.ApiEndPoints;
using MinimalAPI_Second_Tirando_da_Program.AppServiceExtensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddSwagger();
builder.AddPersistence();
builder.Services.AddCors();
builder.AddAuthenticationJwt();

var app = builder.Build();
app.MapAuthenticationEndPoints();
app.MapAssuntosEndPoint();
app.MapAutoresEndPoint();
app.MapLivrosEndPoint();

var environment = app.Environment;
app.UseExceptionHandling(environment)
    .UseSwaggerEndPoints()
    .UseAppCors();

app.UseAuthentication();
app.UseAuthorization();

app.Run();