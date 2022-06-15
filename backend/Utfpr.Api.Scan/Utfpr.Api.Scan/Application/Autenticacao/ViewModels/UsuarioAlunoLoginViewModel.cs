using Utfpr.Api.Scan.Domain.Enumeradores;

namespace Utfpr.Api.Scan.Application.Autenticacao.ViewModels;

public class UsuarioAlunoLoginViewModel
{
    public Guid Id { get; set; }    
    public GoogleUserDataViewModel UserDataViewModel { get; set; }

    public UsuarioAlunoLoginViewModel(Guid id, GoogleUserDataViewModel userDataViewModel)
    {
        Id = id;
        UserDataViewModel = userDataViewModel;
    }
}