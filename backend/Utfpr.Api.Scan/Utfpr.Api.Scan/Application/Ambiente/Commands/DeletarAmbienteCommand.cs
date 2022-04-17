using System.ComponentModel.DataAnnotations.Schema;
using MediatR;

namespace Utfpr.Api.Scan.Application.Ambiente.Commands;

public class DeletarAmbienteCommand : Command
{
    [NotMapped] 
    public Guid Id { get; private set; }

    public DeletarAmbienteCommand(Guid id)
    {
        Id = id;
    }
}