﻿using AutoMapper;
using MediatR;
using Utfpr.Api.Scan.Application.Notificacao.Interfaces;
using Utfpr.Api.Scan.Application.Notificacao.Queries;
using Utfpr.Api.Scan.Application.Notificacao.ViewModels;

namespace Utfpr.Api.Scan.Application.Notificacao.QueryHandlers;

public class ObterNotificacoesAbertasQueryHandlers : IRequestHandler<ObterNotificacoesAbertasQuery, ICollection<NotificacaoViewModel>>
{
    private readonly INotificacaoRepository _ambienteRepository;
    private readonly IMapper _mapper;


    public ObterNotificacoesAbertasQueryHandlers(INotificacaoRepository ambienteRepository, IMapper mapper)
    {
        _ambienteRepository = ambienteRepository;
        _mapper = mapper;
    }

    public async Task<ICollection<NotificacaoViewModel>> Handle(ObterNotificacoesAbertasQuery request, CancellationToken cancellationToken)
    {
        var registro = await _ambienteRepository.ObterNotificacoesEmAberto();

        return _mapper.Map<ICollection<NotificacaoViewModel>>(registro);
    }
}