using Microsoft.AspNetCore.Identity;
using Utfpr.Api.Scan.Domain.Enumeradores;

namespace Utfpr.Api.Scan.Domain.Models.Autenticacao;

public class ApplicationUser : IdentityUser
{
    public TipoUsuarioEnum TipoUsuario { get; set; }
    public string RegistroAcademico { get; set; } = "";

    public ApplicationUser(TipoUsuarioEnum tipoUsuario, string registroAcademico)
    {
        TipoUsuario = tipoUsuario;
        RegistroAcademico = registroAcademico;
    }

    public ApplicationUser() { }
}