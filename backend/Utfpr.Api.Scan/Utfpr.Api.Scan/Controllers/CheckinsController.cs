using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Utfpr.Api.Scan.Application.Checkin.Commands;
using Utfpr.Api.Scan.Application.Checkin.ViewModels;
using Utfpr.Api.Scan.Application.Notification;

namespace Utfpr.Api.Scan.Controllers;

[Route("api/[controller]")]
[AllowAnonymous]
public class CheckinsController : MainController
{
    public CheckinsController(IMediator mediator, INotificationContext notificationContext) : base(mediator, notificationContext)
    {
    }

    [HttpPost]
    public async Task<ActionResult<CheckinViewModel>> RealizaCheckin(
        [FromBody] CadastrarCheckinCommand command)
        => await ExecuteCommandCadastro(command);
}