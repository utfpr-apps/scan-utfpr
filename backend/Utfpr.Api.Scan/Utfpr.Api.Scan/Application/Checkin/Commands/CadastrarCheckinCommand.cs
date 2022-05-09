using System.ComponentModel.DataAnnotations.Schema;
using Utfpr.Api.Scan.Application.Checkin.ViewModels;

namespace Utfpr.Api.Scan.Application.Checkin.Commands;

public class CadastrarCheckinCommand : Command<CheckinViewModel>
{
    [NotMapped]
    public Guid Id { get; private set; }
    [NotMapped]
    public DateTime DataCheckin { get; private set; }
    
    public byte QuantidadeBlocos { get; set; }
    public Guid AmbienteId { get; set; }
    

    public CadastrarCheckinCommand()
    {
        Id = Guid.NewGuid();
        DataCheckin = DateTime.Now; 
    }
}