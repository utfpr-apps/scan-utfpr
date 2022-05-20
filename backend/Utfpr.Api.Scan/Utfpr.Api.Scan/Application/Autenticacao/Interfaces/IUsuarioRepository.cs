using Utfpr.Api.Scan.Application.Autenticacao.ViewModels;
using Utfpr.Api.Scan.Domain.Models.Autenticacao;
using Utfpr.Api.Scan.Infrastructure;

namespace Utfpr.Api.Scan.Application.Autenticacao.Interfaces;

public interface IUsuarioRepository
{
    Task<bool> DeletarLogicamenteUsuario(Guid id);
    Task<ICollection<ApplicationUser>> ObterUsuariosAdmin();
}