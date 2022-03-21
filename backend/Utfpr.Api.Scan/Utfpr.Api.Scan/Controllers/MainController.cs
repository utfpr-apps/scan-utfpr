using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Utfpr.Api.Scan.Application;
using Utfpr.Api.Scan.Application.Notification;

namespace Utfpr.Api.Scan.Controllers;

[ApiController]
public class MainController : ControllerBase
{
    protected IMediator _mediator;
    protected INotificationContext _notificationContext;

    public MainController(IMediator mediator, INotificationContext notificationContext)
    {
        _mediator = mediator;
        _notificationContext = notificationContext;
    }

    protected ActionResult DefineCodigoResponse(object response)
    {
        switch (_notificationContext.Messages.ToList()[0].Codigo)
        {
            case HttpStatusCode.Unauthorized:
                return new UnauthorizedObjectResult("Não autorizado");
            case HttpStatusCode.BadRequest:
                return new BadRequestObjectResult("Objeto de entrada inválido");
            case HttpStatusCode.OK:
                return new OkObjectResult(response);
            case HttpStatusCode.NotFound:
                return new NotFoundObjectResult("Registro não");
        }
        return BadRequest();
    }
}