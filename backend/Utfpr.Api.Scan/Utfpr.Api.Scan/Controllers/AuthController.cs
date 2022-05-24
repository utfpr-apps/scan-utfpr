using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Utfpr.Api.Scan.Application.Autenticacao.Commands;
using Utfpr.Api.Scan.Application.Autenticacao.Queries;
using Utfpr.Api.Scan.Application.Autenticacao.ViewModels;
using Utfpr.Api.Scan.Application.Notification;

namespace Utfpr.Api.Scan.Controllers;

[Route("api/[controller]")]
public class AuthController : MainController
{
    public AuthController(IMediator mediator, INotificationContext notificationContext) : base(mediator, notificationContext)
    {
    }
    
    [HttpPost("login-usuario-app")]
    [AllowAnonymous]
    public async Task<ActionResult<UsuarioAlunoLoginViewModel>> CreateUser(
        [FromBody] CadastrarUsuarioAlunoCommand command)
    {
        var result = await _mediator.Send(command);

        if (result.IsSuccess)
            return Ok(result.Result);

        return DefineCodigoResponse(result.Result);
    }
    
    [HttpPost("criar-usuario-admin")]
    //[Authorize(Roles = "Master")]
    public async Task<ActionResult<UsuarioAlunoLoginViewModel>> CreateUserAdmin(
        [FromBody] CadastrarUsuarioAdminCommand command)
    {
        var result = await _mediator.Send(command);

        if (result.IsSuccess)
            return Ok(result.Result);

        return DefineCodigoResponse(result.Result);
    }
    
    [HttpPost("login-usuario-admin")]
    [AllowAnonymous]
    public async Task<ActionResult<UsuarioAlunoLoginViewModel>> LoginUsuarioAdmin(
        [FromBody] EfetuarAutenticacaoAdminCommand command)
    {
        var result = await _mediator.Send(command);

        if (result.IsSuccess)
            return Ok(result.Result);

        return DefineCodigoResponse(result.Result);
    }

    [HttpDelete("{id:guid}")]
    //[Authorize(Roles = "ADMINISTRADOR")]
    public async Task<ActionResult> DeletarUsuario(Guid id)
    {
        var command = new DeletarUsuarioAdminCommand(id);
        var result = await _mediator.Send(command);

        if (result.IsSuccess)
            return NoContent();

        return DefineCodigoResponse(result.Result);
    }
    
    [HttpGet]
    //[Authorize(Roles = "ADMINISTRADOR")]
    public async Task<ActionResult<ICollection<UsuarioAdminViewModel>>> ObterAmbientes()
        => await ExecuteQueryLista(new ObterUsuariosAdminQuery());
}