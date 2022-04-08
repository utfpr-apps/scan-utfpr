using System.Text.Json.Serialization;
using MediatR;
using Utfpr.Api.Scan.Application.Autenticacao.ViewModels;
using Utfpr.Api.Scan.Domain.Enumeradores;
using Utfpr.Api.Scan.Domain.Models;

namespace Utfpr.Api.Scan.Application.Autenticacao.Commands;

public class CadastrarUsuarioCommand : IRequest<CommandResult<UserViewModel>>
{
    public CadastrarUsuarioCommand(Guid id)
    {
        Id = id;
    }

    [JsonIgnore]
    public Guid Id { get; private set; }
    public string Provider { get; set; }
    public string IdToken { get; set; }
    public TipoUsuarioEnum TipoUsuario { get; set; }
    public string RegistroAcademico { get; set; }
}