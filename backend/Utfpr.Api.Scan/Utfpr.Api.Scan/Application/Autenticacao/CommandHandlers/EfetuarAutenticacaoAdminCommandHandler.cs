﻿using MediatR;
using Utfpr.Api.Scan.Application.Autenticacao.Commands;
using Utfpr.Api.Scan.Application.Autenticacao.ViewModels;
using Utfpr.Api.Scan.Application.Notification;
using Utfpr.Api.Scan.Application.Services;
using Utfpr.Api.Scan.Domain.Models;

namespace Utfpr.Api.Scan.Application.Autenticacao.CommandHandlers;

public class EfetuarAutenticacaoAdminCommandHandler : IRequestHandler<EfetuarAutenticacaoAdminCommand, CommandResult<UsuarioAdminLoginViewModel>>
{
    private readonly INotificationContext _notificationContext;
    private readonly IUserService _userService;

    public EfetuarAutenticacaoAdminCommandHandler(INotificationContext notificationContext, IUserService userService)
    {
        _notificationContext = notificationContext;
        _userService = userService;
    }

    public async Task<CommandResult<UsuarioAdminLoginViewModel>> Handle(EfetuarAutenticacaoAdminCommand request, CancellationToken cancellationToken)
    {
        var userDataViewModel = await _userService.EfetuarLoginAdminGoogle(request);

        if (!_notificationContext.PossuiNotificacoes && userDataViewModel != null)
            return new CommandResult<UsuarioAdminLoginViewModel>(true, new UsuarioAdminLoginViewModel(userDataViewModel.Id, userDataViewModel));

        return new CommandResult<UsuarioAdminLoginViewModel>(_notificationContext.Messages);
    }
}