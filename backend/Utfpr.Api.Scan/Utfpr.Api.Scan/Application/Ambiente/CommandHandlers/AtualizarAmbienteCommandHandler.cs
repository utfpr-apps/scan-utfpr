using System.Net;
using AutoMapper;
using MediatR;
using Utfpr.Api.Scan.Application.Ambiente.Commands;
using Utfpr.Api.Scan.Application.Ambiente.Interfaces;
using Utfpr.Api.Scan.Application.Ambiente.ViewModels;
using Utfpr.Api.Scan.Application.Notification;
using Utfpr.Api.Scan.Domain.Models;

namespace Utfpr.Api.Scan.Application.Ambiente.CommandHandlers;

public class AtualizarAmbienteCommandHandler : IRequestHandler<AtualizarAmbienteCommand, CommandResult<AmbienteViewModel>>
{
    private readonly INotificationContext _notificationContext;
    private readonly IAmbienteRepository _ambienteRepository;
    private readonly IMapper _mapper;

    public AtualizarAmbienteCommandHandler(INotificationContext notificationContext, 
        IAmbienteRepository ambienteRepository, IMapper mapper)
    {
        _notificationContext = notificationContext;
        _ambienteRepository = ambienteRepository;
        _mapper = mapper;
    }

    public async Task<CommandResult<AmbienteViewModel>> Handle(AtualizarAmbienteCommand request, CancellationToken cancellationToken)
    {
        if (!Validacoes(request)) return new CommandResult<AmbienteViewModel>(); 
        
        var registro = await _ambienteRepository.ObterPorId(request.Id);

        if (registro == null)
            return new CommandResult<AmbienteViewModel>();

        registro.CodigoSala = request.CodigoSala;
        registro.TamanhoBloco = request.TamanhoBloco;

        if (await _ambienteRepository.Atualizar(registro))
            return new CommandResult<AmbienteViewModel>(true, _mapper.Map<AmbienteViewModel>(registro));

        return new CommandResult<AmbienteViewModel>();
    }

    private bool Validacoes(AtualizarAmbienteCommand command)
    {
        if (command.TamanhoBloco <= 0)
            _notificationContext.AdicionarNotificacoes(HttpStatusCode.BadRequest, 
                Mensagens.BlocoMaiorQueZero);
        
        if(string.IsNullOrWhiteSpace(command.CodigoSala))
            _notificationContext.AdicionarNotificacoes(HttpStatusCode.BadRequest, 
                Mensagens.NomeAmbienteNaoPodeSerVazio);

        return !_notificationContext.PossuiNotificacoes;
    }
}