﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Utfpr.Api.Scan.Domain.Models.Autenticacao;
using Utfpr.Api.Scan.Infrastructure.Data;

namespace Utfpr.Api.Scan.Configuration;

public static class DatabaseConfiguration
{
    public static IServiceCollection ConfigureDatabase(this IServiceCollection services, 
        IConfiguration configuration, IWebHostEnvironment environment)
    {
        var connection = ConfigureDatabaseConnection(environment.EnvironmentName, configuration);
        
        services.AddDbContext<ApplicationDbContext>(opt =>
            opt.UseNpgsql(connection))
            .AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>();
        
        return services;
    }
    
    private static string ConfigureDatabaseConnection(string environmentName, IConfiguration configuration)
    {
        string defaultConnectionString;

        if (environmentName == "Development") {
            defaultConnectionString = configuration.GetConnectionString("Postgres");
        }
        else
        {
            // Use connection string provided at runtime by Heroku.
            var connectionUrl = Environment.GetEnvironmentVariable("DATABASE_URL");

            connectionUrl = connectionUrl?.Replace("postgres://", string.Empty);
            var userPassSide = connectionUrl?.Split("@")[0];
            var hostSide = connectionUrl?.Split("@")[1];

            var user = userPassSide?.Split(":")[0];
            var password = userPassSide?.Split(":")[1];
            var host = hostSide?.Split("/")[0];
            var database = hostSide?.Split("/")[1].Split("?")[0];

            defaultConnectionString =
                $"Host={host};Database={database};Username={user};Password={password};SSL Mode=Require;Trust Server Certificate=true";
        }

        return defaultConnectionString;
    }
}