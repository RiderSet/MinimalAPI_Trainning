using MinimalAPI_Second_Tirando_da_Program.ApiEndPoints;
using MinimalAPI_Second_Tirando_da_Program.AppServiceExtensions;
using Serilog;

var myAllowSpecificOrigins = "myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

// Add serilog services to the container and read config from appsettings
builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

builder.AddSwagger();

builder.AddPersistence();
builder.AddAuthenticationJwt();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myAllowSpecificOrigins,
        builder =>
        {
            builder.WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader();
        });
});

var app = builder.Build();
app.MapAuthenticationEndPoints();
app.MapAssuntosEndPoint();
app.MapAutoresEndPoint();
app.MapLivrosEndPoint();


var environment = app.Environment;

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandling(environment)
    .UseSwaggerEndPoints()
    .UseAppCors();

app.UseCors(myAllowSpecificOrigins);

app.UseAuthentication();
app.UseAuthorization();

app.Run();

public partial class Program { }