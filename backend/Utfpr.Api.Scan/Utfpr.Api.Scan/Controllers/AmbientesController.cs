using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Utfpr.Api.Scan.Application.Ambiente.Commands;
using Utfpr.Api.Scan.Application.Ambiente.Queries;
using Utfpr.Api.Scan.Application.Ambiente.ViewModels;
using Utfpr.Api.Scan.Application.Notification;

namespace Utfpr.Api.Scan.Controllers;

[Route("api/[controller]")]
[AllowAnonymous]
public class AmbientesController : MainController
{
    public AmbientesController(IMediator mediator, INotificationContext notificationContext) : base(mediator, notificationContext)
    {
    }

    [HttpPost]
    public async Task<ActionResult<AmbienteViewModel>> CreateAmbiente(
        [FromBody] CadastrarAmbienteCommand command)
        => await ExecuteCommandCadastro(command);

    [HttpGet]
    public async Task<ActionResult<ICollection<AmbienteViewModel>>> ObterAmbientes()
        => await ExecuteQueryLista(new ObterAmbientesQuery());

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<AmbienteViewModel>> ObterAmbientePorId(Guid id)
        => await ExecuteQueryPorId(new ObtemAmbientePorIdQuery(id));

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeletarAmbiente(Guid id)
        => await ExecuteCommandDelete(new DeletarAmbienteCommand(id));
}