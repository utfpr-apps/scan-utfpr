using System.Net;
using MediatR;
using Utfpr.Api.Scan.Application.Ambiente.Interfaces;
using Utfpr.Api.Scan.Application.Checkin.Commands;
using Utfpr.Api.Scan.Application.Checkin.Interfaces;
using Utfpr.Api.Scan.Application.Checkin.ViewModels;
using Utfpr.Api.Scan.Application.Notification;
using Utfpr.Api.Scan.Domain.Models;

namespace Utfpr.Api.Scan.Application.Checkin.CommandHandlers;

public class CadastrarCheckinCommandHandler : IRequestHandler<CadastrarCheckinCommand, CommandResult<CheckinViewModel>>
{
    private readonly INotificationContext _notificationContext;
    private readonly ICheckinRepository _checkinRepository;
    private readonly IAmbienteRepository _ambienteRepository;
    
    public CadastrarCheckinCommandHandler(INotificationContext notificationContext, 
        ICheckinRepository checkinRepository, IAmbienteRepository ambienteRepository)
    {
        _notificationContext = notificationContext;
        _checkinRepository = checkinRepository;
        _ambienteRepository = ambienteRepository;
    }

    public async Task<CommandResult<CheckinViewModel>> Handle(CadastrarCheckinCommand request, CancellationToken cancellationToken)
    {
        var registro = await _ambienteRepository.ObterPorId(request.AmbienteId);
        if (registro == null)
        {
            _notificationContext.AdicionarNotificacoes(HttpStatusCode.NotFound, Mensagens.RegistroNaoEncontrado);
            return new CommandResult<CheckinViewModel>();
        }

        var quantidadeMinutosSaida = registro.TamanhoBloco * request.QuantidadeBlocos;
        var checkin = new Domain.Models.Checkin.Checkin(request.DataCheckin, 
            request.DataCheckin.AddMinutes(quantidadeMinutosSaida), request.AmbienteId);
        checkin.Id = request.Id;

        if (await _checkinRepository.Adicionar(checkin))
            return new CommandResult<CheckinViewModel>(true,
                new CheckinViewModel(checkin.Id, checkin.DataCheckin, 
                    checkin.DataFinalizacaoPermanencia));
        
        _notificationContext.AdicionarNotificacoes(HttpStatusCode.BadRequest, Mensagens.ErroAoSalvarOperacao);
        return new CommandResult<CheckinViewModel>();
    }

}