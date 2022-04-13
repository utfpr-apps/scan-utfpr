using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Utfpr.Api.Scan.Application;
using Utfpr.Api.Scan.Application.Notification;

namespace Utfpr.Api.Scan.Controllers;

[ApiController]
public class MainController : ControllerBase
{
    protected readonly IMediator _mediator;
    protected readonly INotificationContext _notificationContext;

    public MainController(IMediator mediator, INotificationContext notificationContext)
    {
        _mediator = mediator;
        _notificationContext = notificationContext;
    }

    protected ActionResult DefineCodigoResponse(object response)
    {
        if(_notificationContext.PossuiNotificacoes)
            switch (_notificationContext.Messages.ToList()[0].Codigo)
            {
                case HttpStatusCode.Unauthorized:
                    return new UnauthorizedObjectResult("Não autorizado");
                case HttpStatusCode.BadRequest:
                    string? message = _notificationContext.Messages.ToList()[0].ErrorMessage;
                    return new BadRequestObjectResult($"Objeto de entrada inválido {message}");
                case HttpStatusCode.NotFound:
                    return new NotFoundObjectResult("Registro não encontrado");
            }
        return new OkObjectResult(response);
    }

    protected async Task<ActionResult<TViewModel>> ExecuteCommandCadastro<TViewModel>(Command<TViewModel> command)
    {
        var result = await _mediator.Send(command);

        if (result.IsSuccess)
            return Ok(result.Result);

        return DefineCodigoResponse(result.Result);
    }
    
    protected async Task<ActionResult<ICollection<TViewModel>>> ExecuteQueryLista<TViewModel>(Query<TViewModel> query)
    {
        var result = await _mediator.Send(query);

        return DefineCodigoResponse(result);
    }
    
    protected async Task<ActionResult<TViewModel>> ExecuteQueryPorId<TViewModel>(Query<TViewModel> query)
    {
        var result = await _mediator.Send(query);

        return DefineCodigoResponse(result);
    }
}