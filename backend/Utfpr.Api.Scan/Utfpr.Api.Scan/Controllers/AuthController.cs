using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Utfpr.Api.Scan.Application.Autenticacao.Commands;
using Utfpr.Api.Scan.Application.Autenticacao.ViewModels;
using Utfpr.Api.Scan.Application.Notification;

namespace Utfpr.Api.Scan.Controllers;

[Route("api/[controller]")]
public class AuthController : MainController
{
    public AuthController(IMediator mediator, INotificationContext notificationContext) : base(mediator, notificationContext)
    {
    }
    
    [HttpPost]
    [AllowAnonymous]
    public async Task<ActionResult<UserViewModel>> CreateUser(
        [FromBody] CadastrarUsuarioCommand command)
    {
        var result = await _mediator.Send(command);

        if (result.IsSuccess)
            return Ok(result.Result);

        return DefineCodigoResponse(result.Result);
    }
}