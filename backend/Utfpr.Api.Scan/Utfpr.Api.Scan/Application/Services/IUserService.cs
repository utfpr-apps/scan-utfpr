using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Utfpr.Api.Scan.Application.Autenticacao.Commands;

namespace Utfpr.Api.Scan.Application.Services;

public interface IUserService
{
    Task<string> EfetuarLoginAlunosGoogle(CadastrarUsuarioAlunoCommand user);
    Task<IdentityResult> CriarUsuarioAdmin(CadastrarUsuarioAdminCommand command);
    Task<string> EfetuarLoginAdminGoogle(EfetuarAutenticacaoAdminCommand command);
}