using MediatR;
using Utfpr.Api.Scan.Application.Notification;

namespace Utfpr.Api.Scan.Controllers;

public class AmbientesController : MainController
{
    public AmbientesController(IMediator mediator, INotificationContext notificationContext) : base(mediator, notificationContext)
    {
    }
    
    
}