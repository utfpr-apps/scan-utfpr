using System.Net;
using Google.Apis.Auth;
using Microsoft.AspNetCore.Identity;
using Utfpr.Api.Scan.Application.Autenticacao.Commands;
using Utfpr.Api.Scan.Application.Autenticacao.ViewModels;
using Utfpr.Api.Scan.Application.Handlers;
using Utfpr.Api.Scan.Application.Notification;
using Utfpr.Api.Scan.Domain.Enumeradores;
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

    public async Task<GoogleUserDataViewModel?> EfetuarLoginAlunosGoogle(CadastrarUsuarioAlunoCommand command)
    {
        try
        {
            var payload = await _jwtHandler.VerifyGoogleToken(command.Token);

            var user = await ObtemUsuarioAlunoGoogle(payload, command);

            if (user != null)
            {
                var userViewModel = new GoogleUserDataViewModel();
                userViewModel.Nome = payload.Name;
                userViewModel.Token = await _jwtHandler.GenerateToken(user);
                userViewModel.UrlFoto = payload.Picture;
                userViewModel.Id = command.Id;
                return userViewModel;
            }
            
            _notificationContext.AdicionarNotificacoes(HttpStatusCode.BadRequest, "Usuário não encontrado");
        }
        catch (InvalidJwtException e)
        {
            _notificationContext.AdicionarNotificacoes(HttpStatusCode.BadRequest, e.Message);
        }

        return null;
    }

    public async Task<IdentityResult> CriarUsuarioAdmin(CadastrarUsuarioAdminCommand command)
    {
        var user = new ApplicationUser
        {
            Email = command.Email,
            UserName = command.Email,
            EmailConfirmed = false,
            Nome = command.Nome,
            Id = command.Id.ToString()
        };

        await _userManager.CreateAsync(user);
        return await _userManager.AddToRoleAsync(user, TipoUsuarioEnum.ADMINISTRADOR.ToString());
    }

    public async Task<GoogleUserDataViewModel?> EfetuarLoginAdminGoogle(EfetuarAutenticacaoAdminCommand command)
    {
        try
        {
            var payload = await _jwtHandler.VerifyGoogleToken(command.Token);

            var user = await ObtemUsuarioAdminGoogle(payload, command);

            if (user != null)
            {
                var userViewModel = new GoogleUserDataViewModel();
                userViewModel.Nome = payload.Name;
                userViewModel.Token = await _jwtHandler.GenerateToken(user);
                userViewModel.UrlFoto = payload.Picture;
                userViewModel.Id = command.Id;
                return userViewModel;
            }
            
            _notificationContext.AdicionarNotificacoes(HttpStatusCode.BadRequest, "Usuário não encontrado");
        }
        catch (InvalidJwtException e)
        {
            _notificationContext.AdicionarNotificacoes(HttpStatusCode.BadRequest, e.Message);
        }

        return null;
    }

    private async Task<ApplicationUser?> ObtemUsuarioAlunoGoogle(GoogleJsonWebSignature.Payload payload,
        CadastrarUsuarioAlunoCommand command)
    {
        var user = await VerifyGoogleUserExistence(command.Provider, payload.Subject, payload.Email);

        IdentityResult result;

        if (user != null)
            return user;

        result = await CreateAlunoGoogleUser(payload, command);
        if (!result.Succeeded)
        {
            _notificationContext.AdicionarNotificacoes(HttpStatusCode.BadRequest, result.Errors.ToString());
            return null;
        }

        user = await VerifyGoogleUserExistence(command.Provider, payload.Subject, payload.Email);

        return user;
    }

    private async Task<ApplicationUser?> ObtemUsuarioAdminGoogle(GoogleJsonWebSignature.Payload payload,
        EfetuarAutenticacaoAdminCommand command)
    {
        return await VerifyGoogleUserExistence(command.Provider, payload.Subject, payload.Email);
    }

    private async Task<ApplicationUser?> VerifyGoogleUserExistence(string provider, string subject, string email)
    {
        var user = await _userManager.FindByEmailAsync(email);

        if (user != null)
        {
            await VinculaUsuarioLoginInfo(user, provider, subject);
            return user;
        }

        user = await _userManager.FindByLoginAsync(provider, subject);

        return user ?? null;
    }

    private async Task<IdentityResult> CreateAlunoGoogleUser(GoogleJsonWebSignature.Payload payload,
        CadastrarUsuarioAlunoCommand command)
    {
        var user = new ApplicationUser
        {
            Email = payload.Email,
            UserName = payload.Email,
            Id = command.Id.ToString(),
            EmailConfirmed = payload.EmailVerified
        };

        await _userManager.CreateAsync(user);
        await VinculaUsuarioLoginInfo(user, command.Provider, payload.Subject);
        return await _userManager.AddToRoleAsync(user, TipoUsuarioEnum.ALUNO.ToString());
    }

    private async Task VinculaUsuarioLoginInfo(ApplicationUser user, string provider, string subject)
    {
        var info = ObterUserLoginInfo(provider, subject);
        await _userManager.AddLoginAsync(user, info);
    }

    private UserLoginInfo ObterUserLoginInfo(string provider, string subject)
    {
        return new UserLoginInfo(provider, subject, provider);
    }
}