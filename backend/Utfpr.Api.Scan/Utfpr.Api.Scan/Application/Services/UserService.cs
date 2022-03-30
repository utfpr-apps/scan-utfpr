using System.Net;
using Google.Apis.Auth;
using Microsoft.AspNetCore.Identity;
using Utfpr.Api.Scan.Application.Autenticacao.Commands;
using Utfpr.Api.Scan.Application.Handlers;
using Utfpr.Api.Scan.Application.Notification;
using Utfpr.Api.Scan.Domain.Models.Autenticacao;

namespace Utfpr.Api.Scan.Application.Services;

public class UserService : IUserService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly INotificationContext _notificationContext;
    private readonly IJwtHandler _jwtHandler;

    public UserService(UserManager<ApplicationUser> userManager, 
        INotificationContext notificationContext, IJwtHandler jwtHandler)
    {
        _userManager = userManager;
        _notificationContext = notificationContext;
        _jwtHandler = jwtHandler;
    }

    public async Task<string> EfetuarLoginDadosGoogle(CadastrarUsuarioCommand command)
    {
        var payload = await _jwtHandler.VerifyGoogleToken(command);

        var user = await ObtemUsuarioGoogle(payload, command);

        if (user != null)
            return await _jwtHandler.GenerateToken(user);
        
        _notificationContext.AdicionarNotificacoes(HttpStatusCode.BadRequest, "Usuário não encontrado");
        return "";
    }

    private async Task<ApplicationUser?> ObtemUsuarioGoogle(GoogleJsonWebSignature.Payload payload, 
        CadastrarUsuarioCommand command)
    {
        var info = new UserLoginInfo(command.Provider, payload.Subject, command.Provider);

        var user = await VerifyGoogleUserExistence(info, payload.Email);

        IdentityResult result;
        
        if (user == null)
        {
            result =  await CreateGoogleUser(payload, command);
            if (!result.Succeeded)
            {
                _notificationContext.AdicionarNotificacoes(HttpStatusCode.BadRequest, result.Errors.ToString());
                return null;
            }
        }
            
        user = await VerifyGoogleUserExistence(info, payload.Email);

        return user;
    }

    private async Task<ApplicationUser?> VerifyGoogleUserExistence(UserLoginInfo info, string email)
    {
        var user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);

        if (user != null)
            return user;
        
        user = await _userManager.FindByEmailAsync(email);

        if (user != null)
            return user;

        await _userManager.AddLoginAsync(user, info);

        return user;
    }

    private async Task<IdentityResult> CreateGoogleUser(GoogleJsonWebSignature.Payload payload, CadastrarUsuarioCommand command)
    {
        var user = new ApplicationUser
        {
            Email = payload.Email,
            UserName = payload.Email,
            TipoUsuario = command.TipoUsuario,
            Id = command.Id.ToString(),
            RegistroAcademico = command.RegistroAcademico,
            EmailConfirmed = payload.EmailVerified
        };

        return await _userManager.CreateAsync(user);
    }
}