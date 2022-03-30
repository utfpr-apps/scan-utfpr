namespace Utfpr.Api.Scan.Domain.Models.Ambientes;

public class Ambiente : Entity
{
    public string CodigoSala { get; set; }
    public byte TamanhoBloco { get; set; }
}