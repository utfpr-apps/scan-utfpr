using MediatR;
using Microsoft.AspNetCore.Mvc;
using Utfpr.Api.Scan.Application.Autenticacao.Commands;
using Utfpr.Api.Scan.Application.Autenticacao.ViewModels;
using Utfpr.Api.Scan.Application.Notification;
using Utfpr.Api.Scan.Application.Services;
using Utfpr.Api.Scan.Domain.Models;

namespace Utfpr.Api.Scan.Application.Autenticacao.CommandHandlers;

public class CadastrarUsuarioAlunoCommandHandler : IRequestHandler<CadastrarUsuarioAlunoCommand, CommandResult<UsuarioAlunoLoginViewModel>>
{
    private readonly INotificationContext _notificationContext;
    private readonly IUserService _userService;

    public CadastrarUsuarioAlunoCommandHandler(INotificationContext notificationContext, IUserService userService)
    {
        _notificationContext = notificationContext;
        _userService = userService;
    }

    public async Task<CommandResult<UsuarioAlunoLoginViewModel>> Handle(CadastrarUsuarioAlunoCommand command, CancellationToken cancellationToken)
    {
        var token = await _userService.EfetuarLoginAlunosGoogle(command);

        if (_notificationContext.PossuiNotificacoes)
            return new CommandResult<UsuarioAlunoLoginViewModel>(_notificationContext.Messages, false);

        return new CommandResult<UsuarioAlunoLoginViewModel>(true, 
            new UsuarioAlunoLoginViewModel(command.Id, token));
    }
}