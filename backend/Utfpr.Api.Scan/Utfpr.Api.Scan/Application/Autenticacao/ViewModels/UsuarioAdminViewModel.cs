namespace Utfpr.Api.Scan.Application.Autenticacao.ViewModels;

public class UsuarioAdminViewModel
{
    public Guid Id { get; set; }
    public string Email { get; set; }

    public UsuarioAdminViewModel(Guid id, string email)
    {
        Id = id;
        Email = email;
    }
}