using System.Text.Json.Serialization;
using Utfpr.Api.Scan.Application.Checkin.ViewModels;

namespace Utfpr.Api.Scan.Application.Checkin.Commands;

public class CadastrarCheckinCommand : Command<CheckinViewModel>
{
    [JsonIgnore]
    public Guid Id { get; private set; }
    [JsonIgnore]
    public DateTime DataCheckin { get; private set; }
    
    public byte QuantidadeBlocos { get; set; }
    public Guid AmbienteId { get; set; }
    public string UserId { get; set; }
    

    public CadastrarCheckinCommand()
    {
        Id = Guid.NewGuid();
        DataCheckin = DateTime.Now; 
    }

    public CadastrarCheckinCommand AtribuirUserId(string userId)
    {
        UserId = userId;
        return this;
    }
}