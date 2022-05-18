using System.ComponentModel.DataAnnotations.Schema;
using MediatR;
using Newtonsoft.Json;

namespace Utfpr.Api.Scan.Application.Ambiente.Commands;

public class DeletarAmbienteCommand : Command
{
    [JsonIgnore] 
    public Guid Id { get; private set; }

    public DeletarAmbienteCommand(Guid id)
    {
        Id = id;
    }
}