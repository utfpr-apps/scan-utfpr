using System.ComponentModel.DataAnnotations.Schema;
using MediatR;
using Utfpr.Api.Scan.Application.Ambiente.ViewModels;

namespace Utfpr.Api.Scan.Application.Ambiente.Queries;

public class ObtemAmbientePorIdQuery : Query<AmbienteViewModel>, IRequest<AmbienteViewModel>
{
    [NotMapped]
    public Guid Id { get; private set; }

    public ObtemAmbientePorIdQuery(Guid id)
    {
        Id = id;
    }
}