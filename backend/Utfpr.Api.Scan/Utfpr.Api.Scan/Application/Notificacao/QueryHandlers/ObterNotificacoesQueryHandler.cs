using AutoMapper;
using MediatR;
using Utfpr.Api.Scan.Application.Notificacao.Interfaces;
using Utfpr.Api.Scan.Application.Notificacao.Queries;
using Utfpr.Api.Scan.Application.Notificacao.ViewModels;
using Utfpr.Api.Scan.Application.Notification;
using Utfpr.Api.Scan.Domain.Enumeradores;

namespace Utfpr.Api.Scan.Application.Notificacao.QueryHandlers;

public class ObterNotificacoesQueryHandler : IRequestHandler<ObterNotificacoesQuery, ListaNotificacaoViewModel>
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

    public async Task<ListaNotificacaoViewModel> Handle(ObterNotificacoesQuery request, CancellationToken cancellationToken)
    {
        var registro = await _ambienteRepository.ObterTodos();

        var listaNotificacaoViewModel = new ListaNotificacaoViewModel();
        listaNotificacaoViewModel.Notificacoes = _mapper.Map<IList<NotificacaoViewModel>>(registro);

        foreach (var notificacaoViewModel in listaNotificacaoViewModel.Notificacoes)
        {
            if (notificacaoViewModel.DataFinalAfastamento > DateTime.Now)
            {
                notificacaoViewModel.Status = StatusNotificacaoEnum.EmAberto;
                listaNotificacaoViewModel.CasosAbertos += 1;
                continue;
            }
                
            notificacaoViewModel.Status = StatusNotificacaoEnum.Terminado;
            listaNotificacaoViewModel.CasosEncerrados += 1;
        }

        listaNotificacaoViewModel.Total =
            listaNotificacaoViewModel.CasosAbertos + listaNotificacaoViewModel.CasosEncerrados;
        
        return listaNotificacaoViewModel;
    }
}