using AutoMapper;
using MediatR;
using Utfpr.Api.Scan.Application.Autenticacao.Interfaces;
using Utfpr.Api.Scan.Application.Autenticacao.Queries;
using Utfpr.Api.Scan.Application.Autenticacao.ViewModels;

namespace Utfpr.Api.Scan.Application.Autenticacao.QueryHandlers;

public class ObterUsuariosAdminQueryHandler : IRequestHandler<ObterUsuariosAdminQuery, ICollection<UsuarioAdminViewModel>>
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IMapper _mapper;
    
    public ObterUsuariosAdminQueryHandler(IUsuarioRepository usuarioRepository, IMapper mapper)
    {
        _usuarioRepository = usuarioRepository;
        _mapper = mapper;
    }

    public async Task<ICollection<UsuarioAdminViewModel>> Handle(ObterUsuariosAdminQuery query, CancellationToken cancellationToken)
    {
        return _mapper.Map<ICollection<UsuarioAdminViewModel>>(await _usuarioRepository.ObterUsuariosAdmin());
    }
}