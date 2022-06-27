using AutoMapper;
using MediatR;
using Utfpr.Api.Scan.Application.Notificacao.Interfaces;
using Utfpr.Api.Scan.Application.Notificacao.Queries;
using Utfpr.Api.Scan.Application.Notificacao.ViewModels;
using Utfpr.Api.Scan.Application.Notification;

namespace Utfpr.Api.Scan.Application.Notificacao.QueryHandlers;

public class ObterNotificacoesQueryHandler : IRequestHandler<ObterNotificacoesQuery, ICollection<NotificacaoViewModel>>
{
    private readonly INotificacaoRepository _ambienteRepository;
    private readonly INotificationContext _notificationContext;
    private readonly IMapper _mapper;

    public ObterNotificacoesQueryHandler(INotificacaoRepository ambienteRepository, INotificationContext notificationContext, IMapper mapper)
    {
        _ambienteRepository = ambienteRepository;
        _notificationContext = notificationContext;
        _mapper = mapper;
    }

    public async Task<ICollection<NotificacaoViewModel>> Handle(ObterNotificacoesQuery request, CancellationToken cancellationToken)
    {
        var registro = await _ambienteRepository.ObterTodos();

        return _mapper.Map<ICollection<NotificacaoViewModel>>(registro);
    }
}