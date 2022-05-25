using MediatR;
using Utfpr.Api.Scan.Application.Autenticacao.Commands;
using Utfpr.Api.Scan.Application.Autenticacao.ViewModels;
using Utfpr.Api.Scan.Application.Notification;
using Utfpr.Api.Scan.Application.Services;
using Utfpr.Api.Scan.Domain.Models;

namespace Utfpr.Api.Scan.Application.Autenticacao.CommandHandlers;

public class
    CadastrarUsuarioAdminCommandHandler : IRequestHandler<CadastrarUsuarioAdminCommand,
        CommandResult<UsuarioAdminViewModel>>
{
    private readonly INotificationContext _notificationContext;
    private readonly IUserService _userService;

    public CadastrarUsuarioAdminCommandHandler(INotificationContext notificationContext, IUserService userService)
    {
        _notificationContext = notificationContext;
        _userService = userService;
    }

    public async Task<CommandResult<UsuarioAdminViewModel>> Handle(CadastrarUsuarioAdminCommand request,
        CancellationToken cancellationToken)
    {
        var result = await _userService.CriarUsuarioAdmin(request);

        if (result.Succeeded)
            return new CommandResult<UsuarioAdminViewModel>(true,
                new UsuarioAdminViewModel(request.Id, request.Email, false, request.Nome));

        return new CommandResult<UsuarioAdminViewModel>(_notificationContext.Messages, false);
    }
}