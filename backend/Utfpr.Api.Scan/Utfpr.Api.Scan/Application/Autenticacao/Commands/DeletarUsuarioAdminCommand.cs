using System.Text.Json.Serialization;
using MediatR;
using Utfpr.Api.Scan.Domain.Models;

namespace Utfpr.Api.Scan.Application.Autenticacao.Commands;

public class DeletarUsuarioAdminCommand : IRequest<CommandResult<bool>>
{
    [JsonIgnore]
    public Guid Id { get; set; }

    public DeletarUsuarioAdminCommand(Guid id)
    {
        Id = id;
    }
}