using System.Text.Json.Serialization;
using MediatR;
using Utfpr.Api.Scan.Application.Autenticacao.ViewModels;
using Utfpr.Api.Scan.Domain.Models;

namespace Utfpr.Api.Scan.Application.Autenticacao.Commands;

public class EfetuarAutenticacaoAdminCommand : IRequest<CommandResult<UsuarioAdminLoginViewModel>>
{
    public EfetuarAutenticacaoAdminCommand()
    {
        Id = Guid.NewGuid();
    }

    [JsonIgnore]
    public Guid Id { get; private set; }
    public string Provider { get; set; }
    public string Token { get; set; }
}