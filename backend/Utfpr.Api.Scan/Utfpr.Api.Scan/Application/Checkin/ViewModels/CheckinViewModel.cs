namespace Utfpr.Api.Scan.Application.Checkin.ViewModels;

public class CheckinViewModel : BaseViewModel
{
    public Guid Id { get; set; }
    public DateTime HoraInicialCheckin { get; set; }
    public DateTime HoraFinalCheckin { get; set; }

    public CheckinViewModel(Guid id, DateTime horaInicialCheckin, DateTime horaFinalCheckin)
    {
        Id = id;
        HoraInicialCheckin = horaInicialCheckin;
        HoraFinalCheckin = horaFinalCheckin;
    }
}