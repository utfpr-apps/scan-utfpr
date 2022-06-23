using AutoMapper;
using Utfpr.Api.Scan.Application.Notificacao.ViewModels;

namespace Utfpr.Api.Scan.Application.Notificacao;

public class NotificacaoAutoMapper : Profile
{
    public NotificacaoAutoMapper()
    {
        CreateMap<Domain.Models.Notificacao.Notificacao, NotificacaoViewModel>();
    }
}