using Microsoft.AspNetCore.Mvc;
using Utfpr.Api.Scan.Application.Autenticacao.Commands;

namespace Utfpr.Api.Scan.Application.Services;

public interface IUserService
{
    Task<string> EfetuarLoginDadosGoogle(CadastrarUsuarioCommand user);
}