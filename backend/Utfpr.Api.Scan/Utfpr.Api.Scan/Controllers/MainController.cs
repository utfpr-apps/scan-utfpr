using System.Net;
using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Utfpr.Api.Scan.Application;
using Utfpr.Api.Scan.Application.Notification;

namespace Utfpr.Api.Scan.Controllers;

[ApiController]
public class MainController : ControllerBase
{
    protected readonly IMediator Mediator;
    protected readonly INotificationContext NotificationContext;
    protected string? UserId => User.FindFirst(i => i.Type == ClaimTypes.NameIdentifier)?.Value;

    public MainController(IMediator mediator, INotificationContext notificationContext)
    {
        Mediator = mediator;
        NotificationContext = notificationContext;
    }

    protected ActionResult DefineCodigoResponse(object response)
    {
        if (NotificationContext.PossuiNotificacoes)
        {
            var error = new ErrorObjectMessage(NotificationContext.Code, NotificationContext.Messages);
            switch (NotificationContext.Code)
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
        var result = await Mediator.Send(command);

        if (result.IsSuccess)
            return Ok(result.Result);

        return DefineCodigoResponse(result.Result);
    }
    
    protected async Task<ActionResult<TViewModel>> ExecuteCommandAtualizacao<TViewModel>(Command<TViewModel> command)
    {
        var result = await Mediator.Send(command);

        if (result.IsSuccess)
            return Ok(result.Result);

        return DefineCodigoResponse(result.Result);
    }

    protected async Task<ActionResult> ExecuteCommandDelete(Command command)
    {
        var result = await Mediator.Send(command);

        if (result)
            return NoContent();

        return DefineCodigoResponse(result);
    }

    
    protected async Task<ActionResult<ICollection<TViewModel>>> ExecuteQueryLista<TViewModel>(Query<ICollection<TViewModel>> query)
    {
        var result = await Mediator.Send(query);

        return DefineCodigoResponse(result);
    }
    
    protected async Task<ActionResult<TViewModel>> ExecuteQueryPorId<TViewModel>(Query<TViewModel> query)
    {
        var result = await Mediator.Send(query);

        return DefineCodigoResponse(result);
    }
}