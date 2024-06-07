using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MinimalAPI_Second_Tirando_da_Program.Context;
using MinimalAPI_Second_Tirando_da_Program.Repositories;
using MinimalAPI_Second_Tirando_da_Program.Repositories.Interfaces;
using MinimalAPI_Second_Tirando_da_Program.Services;
using MinimalAPI_Second_Tirando_da_Program.Services.Interfaces;
using System.Text;

namespace MinimalAPI_Second_Tirando_da_Program.AppServiceExtensions
{
    public static class ServiceCollectionExtensions
    {
        public static WebApplicationBuilder AddSwagger(this WebApplicationBuilder builder)
        {
            builder.Services.AddSwagger();
            return builder;
        }

        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MinimalAPI", Version = "v1" });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = @"JWT Authorization header using the bearer scheme. Enter 'Bearer [].Example: \'Bearer 123456abcdefg'",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });
            return services;
        }

        public static WebApplicationBuilder AddAuthenticationJwt(this WebApplicationBuilder builder)
        {
            builder.Services.AddAuthentication

                (JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,

                        ValidIssuer = builder.Configuration["Jwt:Issuer"],
                        ValidAudience = builder.Configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey

                        (Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                    };
                });
            builder.Services.AddAuthorization();
            return builder;
        }

        public static WebApplicationBuilder AddPersistence(this WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("Conn");

            builder.Services.AddDbContext<CTX>(options => options.UseSqlServer(connectionString));
            builder.Services.AddSingleton<IRepositoryToken>(new ServiceToken());

            builder.Services.AddScoped<IServiceAssunto, ServiceAssunto>();
            builder.Services.AddScoped<IRepositoryAssunto, RepositoryAssunto>();

            return builder;
        }
    }
}

