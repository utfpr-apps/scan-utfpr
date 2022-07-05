using MediatR;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Roles = "ALUNO")]
    public async Task<ActionResult<NotificacaoViewModel>> CriaNotificacao(CadastrarNotificacaoCommand command)
        => await ExecuteCommandCadastro(command.AtribuirUsuarioId(UserId));

    [HttpGet("notificacoes-abertas")]
    [Authorize(Roles = "ADMINISTRADOR")]
    public async Task<ActionResult<ICollection<NotificacaoViewModel>>> ObterNotificacoesAbertas()
        => await ExecuteQueryLista(new ObterNotificacoesAbertasQuery());

    [HttpGet]
    [Authorize(Roles = "ADMINISTRADOR")]
    public async Task<ActionResult<ListaNotificacaoViewModel>> ObterNotificacoes()
        => await ExecuteQueryPorId(new ObterNotificacoesQuery());

    [HttpGet("{id:guid}/emails")]
    [Authorize(Roles = "ADMINISTRADOR")]
    public async Task<ActionResult<ListaEmailContatoNotificacaoViewModel>> ObterListaEmailContato(Guid id)
        => await ExecuteQueryPorId(new ObterListaEmailsContatoQuery(id));
}