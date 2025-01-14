﻿namespace Utfpr.Api.Scan.Application.Autenticacao.ViewModels;

public class UsuarioAdminViewModel
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public bool Inativo { get; set; }
    public string Nome { get; set; }

    public UsuarioAdminViewModel(Guid id, string email, bool inativo, string nome)
    {
        Id = id;
        Email = email;
        Inativo = inativo;
        Nome = nome;
    }
}