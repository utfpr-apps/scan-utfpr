using System.ComponentModel.DataAnnotations.Schema;
using MediatR;
using Utfpr.Api.Scan.Application.Autenticacao.ViewModels;
using Utfpr.Api.Scan.Domain.Enumeradores;
using Utfpr.Api.Scan.Domain.Models;

namespace Utfpr.Api.Scan.Application.Autenticacao.Commands;

public class CadastrarUsuarioAdminCommand : IRequest<CommandResult<UsuarioAdminViewModel>>
{
    [NotMapped]
    public Guid Id { get; private set; }
    public string Email { get; set; }
    public string Nome { get; set; }

    public CadastrarUsuarioAdminCommand(Guid id, string email, string nome)
    {
        Id = id;
        Email = email;
        Nome = nome;
    }
}