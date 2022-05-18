using System.Text.Json.Serialization;
using MediatR;
using Utfpr.Api.Scan.Application.Autenticacao.ViewModels;
using Utfpr.Api.Scan.Domain.Models;

namespace Utfpr.Api.Scan.Application.Autenticacao.Commands;

public class CadastrarUsuarioAdminCommand : IRequest<CommandResult<UsuarioAdminViewModel>>
{
    [JsonIgnore]
    public Guid Id { get; private set; }
    public string Email { get; set; }
    public string Nome { get; set; }

    public CadastrarUsuarioAdminCommand(Guid id, string email, string nome)
    {
        Id = Guid.NewGuid();
        Email = email;
        Nome = nome;
    }
}