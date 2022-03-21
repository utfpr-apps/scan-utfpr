using Utfpr.Api.Scan.Domain.Enumeradores;

namespace Utfpr.Api.Scan.Application.Autenticacao.ViewModels;

public class UserViewModel
{
    public Guid Id { get; set; }    
    public TipoUsuarioEnum TipoUsuario { get; set; }
    public string RegistroAcademico { get; set; } = "";
    public string Token { get; set; }

    public UserViewModel(Guid id, TipoUsuarioEnum tipoUsuario, string registroAcademico, string token)
    {
        Id = id;
        TipoUsuario = tipoUsuario;
        RegistroAcademico = registroAcademico;
        Token = token;
    }
}