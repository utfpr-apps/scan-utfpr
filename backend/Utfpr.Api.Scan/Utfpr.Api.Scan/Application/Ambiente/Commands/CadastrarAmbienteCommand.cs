using MediatR;
using Newtonsoft.Json;
using Utfpr.Api.Scan.Application.Ambiente.ViewModels;
using Utfpr.Api.Scan.Domain.Enumeradores;
using Utfpr.Api.Scan.Domain.Models;

namespace Utfpr.Api.Scan.Application.Ambiente.Commands;

public class CadastrarAmbienteCommand : Command<AmbienteViewModel>
{
    public CadastrarAmbienteCommand()
    {
        Id = Guid.NewGuid();
    }

    [JsonIgnore] 
    public Guid Id { get; private set; }
    public string CodigoSala { get; set; }
    public byte TamanhoBloco { get; set; }
}