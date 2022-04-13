using System.Net;
using AutoMapper;
using MediatR;
using Utfpr.Api.Scan.Application.Ambiente.Interfaces;
using Utfpr.Api.Scan.Application.Ambiente.Queries;
using Utfpr.Api.Scan.Application.Ambiente.ViewModels;
using Utfpr.Api.Scan.Application.Notification;

namespace Utfpr.Api.Scan.Application.Ambiente.QueryHandlers;

public class ObtemAmbientePorIdQueryHandler : IRequestHandler<ObtemAmbientePorIdQuery, AmbienteViewModel>
{
    private readonly IAmbienteRepository _ambienteRepository;
    private readonly INotificationContext _notificationContext;
    private readonly IMapper _mapper;
    
    public ObtemAmbientePorIdQueryHandler(IAmbienteRepository ambienteRepository, 
        INotificationContext notificationContext, IMapper mapper)
    {
        _ambienteRepository = ambienteRepository;
        _notificationContext = notificationContext;
        _mapper = mapper;
    }

    public async Task<AmbienteViewModel> Handle(ObtemAmbientePorIdQuery query, CancellationToken cancellationToken)
    {
        var registro = await _ambienteRepository.ObterPorId(query.Id);

        if (registro != null)
            return _mapper.Map<AmbienteViewModel>(registro);

        _notificationContext.AdicionarNotificacoes(HttpStatusCode.BadRequest, 
            Mensagens.RegistroNaoEncontrado);
        return new AmbienteViewModel();
    }
}