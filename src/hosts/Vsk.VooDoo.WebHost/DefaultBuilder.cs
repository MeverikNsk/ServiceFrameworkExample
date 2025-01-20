namespace Vsk.VooDoo.WebHost
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.OpenApi.Models;
    using Vsk.VooDoo.Core.Extensions;

    public static class DefaultBuilder
    {
        public static WebApplicationBuilder CreateDefaultBuilder(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddEndpointsApiExplorer();
            builder.Configuration.AddEnvironmentVariables();
            builder.Services.AddControllers().AddJsonOptions(x =>
            {
                // serialize enums as strings in api responses (e.g. Role)
                x.JsonSerializerOptions.PropertyNamingPolicy = null;
            });

            // Добавление swagger-а
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "VooDoo",
                    Description = "Web API for managing VooDoo",
                });

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme.<br>" +
                                  "Enter 'Bearer' [space] and then your token in the text input below.<br><br>" +
                                  "Example: 'Bearer 12345abcdef'<br><br>",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        },
                        new List<string>()
                    }
                });
            });

            // Инициализация модулей сервиса
            builder.Services.InitServiceModules(["Vsk.VooDoo"]);

            return builder;
        }
    }
}
