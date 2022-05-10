using System.Net;
using MediatR;
using Utfpr.Api.Scan.Application.Ambiente.Commands;
using Utfpr.Api.Scan.Application.Ambiente.Interfaces;
using Utfpr.Api.Scan.Application.Ambiente.ViewModels;
using Utfpr.Api.Scan.Application.Notification;
using Utfpr.Api.Scan.Domain.Models;

namespace Utfpr.Api.Scan.Application.Ambiente.CommandHandlers;

public class CadastrarAmbienteCommandHandler  : IRequestHandler<CadastrarAmbienteCommand, CommandResult<AmbienteViewModel>>
{
    private readonly INotificationContext _notificationContext;
    private readonly IAmbienteRepository _ambienteRepository;

    public CadastrarAmbienteCommandHandler(INotificationContext notificationContext, IAmbienteRepository ambienteRepository)
    {
        _notificationContext = notificationContext;
        _ambienteRepository = ambienteRepository;
    }

    public async Task<CommandResult<AmbienteViewModel>> Handle(CadastrarAmbienteCommand command, CancellationToken cancellationToken)
    {
        if (!Validacoes(command)) return new CommandResult<AmbienteViewModel>();
        
        var registro = new Domain.Models.Ambientes.Ambiente(command.Id, command.CodigoSala, command.TamanhoBloco);
        if (!await _ambienteRepository.Adicionar(registro))
            return new CommandResult<AmbienteViewModel>(_notificationContext.Messages, false);

        return new CommandResult<AmbienteViewModel>(true, new AmbienteViewModel(registro.Id, registro.CodigoSala, registro.TamanhoBloco));
    }
    
    private bool Validacoes(CadastrarAmbienteCommand command)
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