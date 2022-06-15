namespace Utfpr.Api.Scan.Application.Autenticacao.ViewModels;

public class UsuarioAdminLoginViewModel
{
    public Guid Id { get; set; }
    public GoogleUserDataViewModel UserDataViewModel { get; set; }

    public UsuarioAdminLoginViewModel(Guid id, GoogleUserDataViewModel userDataViewModel)
    {
        Id = id;
        UserDataViewModel = userDataViewModel;
    }
}