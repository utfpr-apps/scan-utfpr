using AutoMapper;
using MediatR;
using Utfpr.Api.Scan.Application.Notificacao.Commands;
using Utfpr.Api.Scan.Application.Notificacao.Interfaces;
using Utfpr.Api.Scan.Application.Notificacao.ViewModels;
using Utfpr.Api.Scan.Application.Notification;
using Utfpr.Api.Scan.Domain.Models;

namespace Utfpr.Api.Scan.Application.Notificacao.CommandHandlers;

public class CadastrarNotificacaoCommandHandler : IRequestHandler<CadastrarNotificacaoCommand, CommandResult<NotificacaoViewModel>>
{
    private readonly INotificationContext _notificationContext;
    private readonly INotificacaoRepository _notificacaoRepository;
    private readonly IMapper _mapper;
    
    public CadastrarNotificacaoCommandHandler(INotificationContext notificationContext, 
        INotificacaoRepository notificacaoRepository, IMapper mapper)
    {
        _notificationContext = notificationContext;
        _notificacaoRepository = notificacaoRepository;
        _mapper = mapper;
    }

    public async Task<CommandResult<NotificacaoViewModel>> Handle(CadastrarNotificacaoCommand request, CancellationToken cancellationToken)
    {
        var registro = new Domain.Models.Notificacao.Notificacao(request.DataInicialAfastamento, request.DataFinalAfastamento, 
            request.UsuarioId, request.Imagem);
        
        if (await _notificacaoRepository.Adicionar(registro))
            return new CommandResult<NotificacaoViewModel>(true,
                _mapper.Map<NotificacaoViewModel>(registro));

        return new CommandResult<NotificacaoViewModel>();
    }
}