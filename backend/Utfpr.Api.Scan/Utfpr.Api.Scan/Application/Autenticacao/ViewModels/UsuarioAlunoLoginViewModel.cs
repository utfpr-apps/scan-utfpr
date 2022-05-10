using Utfpr.Api.Scan.Domain.Enumeradores;

namespace Utfpr.Api.Scan.Application.Autenticacao.ViewModels;

public class UsuarioAlunoLoginViewModel
{
    public Guid Id { get; set; }    
    public string Token { get; set; }

    public UsuarioAlunoLoginViewModel(Guid id, string token)
    {
        Id = id;
        Token = token;
    }
}