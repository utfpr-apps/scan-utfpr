using Microsoft.AspNetCore.Identity;
using Utfpr.Api.Scan.Application.Seeders;
using Utfpr.Api.Scan.Domain.Models.Autenticacao;

namespace Utfpr.Api.Scan.Configuration;

public static class UsuariosConfiguration
{
    public static async Task CriaEstruturaUsuarios(this IServiceProvider services)
    {
        var loggerFactory = services.GetRequiredService<ILoggerFactory>();
        var logger = loggerFactory.CreateLogger("app");
        try
        {
            var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
            await RolesSeeder.SeedRolesAsync(roleManager);
            await RolesSeeder.SeedMasterUserAsync(userManager);
            logger.LogInformation("Seed de usuários e roles finalizados");
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "Um erro ocorreu ao executar o seed");
        }
    }
}