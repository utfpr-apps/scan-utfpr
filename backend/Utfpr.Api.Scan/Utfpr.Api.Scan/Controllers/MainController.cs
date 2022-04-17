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
        if (_notificationContext.PossuiNotificacoes)
        {
            var error = new ErrorObjectMessage(_notificationContext.Code, _notificationContext.Messages);
            switch (_notificationContext.Code)
            { 
                case HttpStatusCode.Unauthorized:
                    return new UnauthorizedObjectResult(error);
                case HttpStatusCode.BadRequest:
                    return new BadRequestObjectResult(error);
                case HttpStatusCode.NotFound:
                    return new NotFoundObjectResult(error);
            }
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
    
    protected async Task<ActionResult<TViewModel>> ExecuteCommandAtualizacao<TViewModel>(Command<TViewModel> command)
    {
        var result = await _mediator.Send(command);

        if (result.IsSuccess)
            return Ok(result.Result);

        return DefineCodigoResponse(result.Result);
    }

    protected async Task<ActionResult> ExecuteCommandDelete(Command command)
    {
        var result = await _mediator.Send(command);

        if (result)
            return NoContent();

        return DefineCodigoResponse(result);
    }

    
    protected async Task<ActionResult<ICollection<TViewModel>>> ExecuteQueryLista<TViewModel>(Query<ICollection<TViewModel>> query)
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