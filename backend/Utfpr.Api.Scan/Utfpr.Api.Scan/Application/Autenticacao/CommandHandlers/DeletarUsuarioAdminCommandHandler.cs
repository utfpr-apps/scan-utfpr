using MediatR;
using Utfpr.Api.Scan.Application.Autenticacao.Commands;
using Utfpr.Api.Scan.Application.Autenticacao.Interfaces;
using Utfpr.Api.Scan.Application.Notification;
using Utfpr.Api.Scan.Domain.Models;

namespace Utfpr.Api.Scan.Application.Autenticacao.CommandHandlers;

public class DeletarUsuarioAdminCommandHandler : IRequestHandler<DeletarUsuarioAdminCommand, CommandResult<bool>>
{
    private readonly INotificationContext _notificationContext;
    private readonly IUsuarioRepository _usuarioRepository;

    public DeletarUsuarioAdminCommandHandler(INotificationContext notificationContext, 
        IUsuarioRepository usuarioRepository)
    {
        _notificationContext = notificationContext;
        _usuarioRepository = usuarioRepository;
    }

    public async Task<CommandResult<bool>> Handle(DeletarUsuarioAdminCommand request, CancellationToken cancellationToken)
    {
        if (await _usuarioRepository.DeletarLogicamenteUsuario(request.Id))
            return new CommandResult<bool>(true, true);

        return new CommandResult<bool>();
    }
}