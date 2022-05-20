using AutoMapper;
using Utfpr.Api.Scan.Application.Autenticacao.ViewModels;
using Utfpr.Api.Scan.Domain.Models.Autenticacao;

namespace Utfpr.Api.Scan.Application.Autenticacao;

public class UsuariosAutoMapper : Profile
{
    public UsuariosAutoMapper()
    {
        CreateMap<ApplicationUser, UsuarioAdminViewModel>();
    }
}