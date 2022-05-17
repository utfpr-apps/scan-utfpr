using Microsoft.AspNetCore.Identity;
using Utfpr.Api.Scan.Domain.Enumeradores;
using Utfpr.Api.Scan.Domain.Models.Autenticacao;

namespace Utfpr.Api.Scan.Application.Seeders;

public static class RolesSeeder
{
    public static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
    {
        await roleManager.CreateAsync(new IdentityRole(TipoUsuarioEnum.ALUNO.ToString()));
        await roleManager.CreateAsync(new IdentityRole(TipoUsuarioEnum.ADMINISTRADOR.ToString()));
        await roleManager.CreateAsync(new IdentityRole(TipoUsuarioEnum.MASTER.ToString()));
    }

    public static async Task SeedMasterUserAsync(UserManager<ApplicationUser> userManager)
    {
        var emailMaster = Environment.GetEnvironmentVariable("EMAIL_MASTER");
        var masterUser = new ApplicationUser
        {
            UserName = emailMaster,
            Email = emailMaster,
            EmailConfirmed = true,
            Nome = "Administrador"
        };
        
        if (userManager.Users.All(u => u.Id != masterUser.Id))
        {
            var user = await userManager.FindByEmailAsync(masterUser.Email);
            if (user == null)
            {
                await userManager.CreateAsync(masterUser, Environment.GetEnvironmentVariable("PASSWORD_MASTER"));
                await userManager.AddToRoleAsync(masterUser, TipoUsuarioEnum.MASTER.ToString());
                await userManager.AddToRoleAsync(masterUser, TipoUsuarioEnum.ADMINISTRADOR.ToString());
            }
        }
    }
}