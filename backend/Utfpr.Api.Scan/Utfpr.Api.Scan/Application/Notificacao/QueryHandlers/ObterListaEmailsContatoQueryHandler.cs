using System.Net;
using AutoMapper;
using MediatR;
using Utfpr.Api.Scan.Application.Checkin.Interfaces;
using Utfpr.Api.Scan.Application.Notificacao.Interfaces;
using Utfpr.Api.Scan.Application.Notificacao.Queries;
using Utfpr.Api.Scan.Application.Notificacao.ViewModels;
using Utfpr.Api.Scan.Application.Notification;

namespace Utfpr.Api.Scan.Application.Notificacao.QueryHandlers;

public class
    ObterListaEmailsContatoQueryHandler : IRequestHandler<ObterListaEmailsContatoQuery,
        ListaEmailContatoNotificacaoViewModel>
{
    private readonly INotificationContext _notificationContext;
    private readonly IMapper _mapper;
    private readonly INotificacaoRepository _notificacaoRepository;

    public ObterListaEmailsContatoQueryHandler(INotificationContext notificationContext, IMapper mapper,
        INotificacaoRepository notificacaoRepository)
    {
        _notificationContext = notificationContext;
        _mapper = mapper;
        _notificacaoRepository = notificacaoRepository;
    }

    public async Task<ListaEmailContatoNotificacaoViewModel> Handle(ObterListaEmailsContatoQuery request,
        CancellationToken cancellationToken)
    {
        var registro = await _notificacaoRepository.ObterPorId(request.Id);

        if (registro == null)
        {
            _notificationContext.AdicionarNotificacoes(HttpStatusCode.NotFound,
                Mensagens.RegistroNaoEncontrado);
            return new ListaEmailContatoNotificacaoViewModel();
        }

        return new ListaEmailContatoNotificacaoViewModel
        {
            Emails = await _notificacaoRepository.ObterEmailsContato(request.Id)
        };
    }
}