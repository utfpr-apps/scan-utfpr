using AutoMapper;
using MediatR;
using Utfpr.Api.Scan.Application.Ambiente.Interfaces;
using Utfpr.Api.Scan.Application.Ambiente.Queries;
using Utfpr.Api.Scan.Application.Ambiente.ViewModels;

namespace Utfpr.Api.Scan.Application.Ambiente.QueryHandlers;

public class ObterAmbientesQueryHandler : IRequestHandler<ObterAmbientesQuery, ICollection<AmbienteViewModel>>
{
    private readonly IAmbienteRepository _ambienteRepository;
    private readonly IMapper _mapper;

    public ObterAmbientesQueryHandler(IAmbienteRepository ambienteRepository, IMapper mapper)
    {
        _ambienteRepository = ambienteRepository;
        _mapper = mapper;
    }

    public async Task<ICollection<AmbienteViewModel>> Handle(ObterAmbientesQuery query, CancellationToken cancellationToken)
    {
        return _mapper.Map<ICollection<AmbienteViewModel>>(await _ambienteRepository.ObterTodos());   
    }
    
}