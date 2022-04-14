using AutoMapper;
using Utfpr.Api.Scan.Application.Ambiente.ViewModels;

namespace Utfpr.Api.Scan.Application.Ambiente;

public class AmbienteProfile : Profile
{
    public AmbienteProfile()
    {
        CreateMap<Domain.Models.Ambientes.Ambiente, AmbienteViewModel>();
    }
}