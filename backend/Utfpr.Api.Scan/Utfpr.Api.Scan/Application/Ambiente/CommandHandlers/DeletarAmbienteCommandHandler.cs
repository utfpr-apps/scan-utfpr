using MediatR;
using Utfpr.Api.Scan.Application.Ambiente.Commands;
using Utfpr.Api.Scan.Application.Ambiente.Interfaces;
using Utfpr.Api.Scan.Application.Notification;

namespace Utfpr.Api.Scan.Application.Ambiente.CommandHandlers;

public class DeletarAmbienteCommandHandler : IRequestHandler<DeletarAmbienteCommand, bool>
{
    private readonly IAmbienteRepository _ambienteRepository;

    public DeletarAmbienteCommandHandler(IAmbienteRepository ambienteRepository)
    {
        _ambienteRepository = ambienteRepository;
    }

    public async Task<bool> Handle(DeletarAmbienteCommand command, CancellationToken cancellationToken)
    {
        return await _ambienteRepository.Deletar(command.Id);
    }
}