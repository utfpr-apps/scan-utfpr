using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Utfpr.Api.Scan.Application.Ambiente.Commands;
using Utfpr.Api.Scan.Application.Ambiente.Queries;
using Utfpr.Api.Scan.Application.Ambiente.ViewModels;
using Utfpr.Api.Scan.Application.Notification;

namespace Utfpr.Api.Scan.Controllers;

[Route("api/[controller]")]
public class AmbientesController : MainController
{
    public AmbientesController(IMediator mediator, INotificationContext notificationContext) : base(mediator, notificationContext)
    {
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<ActionResult<AmbienteViewModel>> CreateAmbiente(
        [FromBody] CadastrarAmbienteCommand command)
        => await ExecuteCommandCadastro(command);

    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<ICollection<AmbienteViewModel>>> ObterAmbientes()
        => await ExecuteQueryLista(new ObterAmbientesQuery());
}