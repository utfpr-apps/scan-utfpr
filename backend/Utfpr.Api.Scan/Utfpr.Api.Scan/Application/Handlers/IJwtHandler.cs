using Google.Apis.Auth;
using Utfpr.Api.Scan.Application.Autenticacao.Commands;
using Utfpr.Api.Scan.Domain.Models.Autenticacao;

namespace Utfpr.Api.Scan.Application.Handlers;

public interface IJwtHandler
{
    Task<GoogleJsonWebSignature.Payload> VerifyGoogleToken(string token);
    Task<string> GenerateToken(ApplicationUser user);
}