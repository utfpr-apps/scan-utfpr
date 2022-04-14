namespace Utfpr.Api.Scan.Application.Ambiente.ViewModels;

public class AmbienteViewModel : BaseViewModel
{
    public Guid Id { get; set; }
    public string CodigoSala { get; set; }
    public byte TamanhoBloco { get; set; }

    public AmbienteViewModel(Guid id, string codigoSala, byte tamanhoBloco)
    {
        Id = id;
        CodigoSala = codigoSala;
        TamanhoBloco = tamanhoBloco;
    }

    public AmbienteViewModel()
    {
        
    }
}