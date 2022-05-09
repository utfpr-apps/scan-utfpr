namespace Utfpr.Api.Scan.Application.Autenticacao.ViewModels;

public class UsuarioAdminLoginViewModel
{
    public string Token { get; set; }

    public UsuarioAdminLoginViewModel(string token)
    {
        Token = token;
    }
}