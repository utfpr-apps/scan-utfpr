using MediatR;
using Microsoft.AspNetCore.Mvc;
using Utfpr.Api.Scan.Application.Autenticacao.Commands;
using Utfpr.Api.Scan.Application.Autenticacao.ViewModels;
using Utfpr.Api.Scan.Application.Notification;
using Utfpr.Api.Scan.Application.Services;
using Utfpr.Api.Scan.Domain.Models;

namespace Utfpr.Api.Scan.Application.Autenticacao.CommandHandlers;

public class CadastrarUsuarioCommandHandler : IRequestHandler<CadastrarUsuarioCommand, CommandResult<UserViewModel>>
{
    private readonly INotificationContext _notificationContext;
    private readonly IUserService _userService;

    public CadastrarUsuarioCommandHandler(INotificationContext notificationContext, IUserService userService)
    {
        _notificationContext = notificationContext;
        _userService = userService;
    }

    public async Task<CommandResult<UserViewModel>> Handle(CadastrarUsuarioCommand command, CancellationToken cancellationToken)
    {
        var token = await _userService.EfetuarLoginDadosGoogle(command);

        if (_notificationContext.PossuiNotificacoes)
            return new CommandResult<UserViewModel>(_notificationContext.Messages, false);

        return new CommandResult<UserViewModel>(true, 
            new UserViewModel(command.Id, command.TipoUsuario, command.RegistroAcademico, token));
    }
}