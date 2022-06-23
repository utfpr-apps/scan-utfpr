﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Utfpr.Api.Scan.Application.Notificacao.Commands;
using Utfpr.Api.Scan.Application.Notificacao.Queries;
using Utfpr.Api.Scan.Application.Notificacao.ViewModels;
using Utfpr.Api.Scan.Application.Notification;

namespace Utfpr.Api.Scan.Controllers;

[Route("api/[controller]")]
public class NotificacoesController : MainController
{
    public NotificacoesController(IMediator mediator, INotificationContext notificationContext) : base(mediator, notificationContext)
    {
    }

    [HttpPost]
    public async Task<ActionResult<NotificacaoViewModel>> CriaNotificacao(CadastrarNotificacaoCommand command)
        => await ExecuteCommandCadastro(command.AtribuirUsuarioId(UserId));

    [HttpGet]
    public async Task<ActionResult<ICollection<NotificacaoViewModel>>> ObterNotificacoesAbertas(
        ObterNotificacoesAbertasQuery query)
        => await ExecuteQueryLista(query);
}