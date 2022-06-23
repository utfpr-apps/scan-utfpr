using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Utfpr.Api.Scan.Application.Autenticacao.Commands;
using Utfpr.Api.Scan.Application.Autenticacao.ViewModels;

namespace Utfpr.Api.Scan.Application.Services;

public interface IUserService
{
    Task<GoogleUserDataViewModel?> EfetuarLoginAlunosGoogle(CadastrarUsuarioAlunoCommand user);
    Task<IdentityResult> CriarUsuarioAdmin(CadastrarUsuarioAdminCommand command);
    Task<GoogleUserDataViewModel?> EfetuarLoginAdminGoogle(EfetuarAutenticacaoAdminCommand command);
}