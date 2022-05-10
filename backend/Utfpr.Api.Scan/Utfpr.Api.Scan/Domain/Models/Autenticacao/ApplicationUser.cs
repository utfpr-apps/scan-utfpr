﻿using Microsoft.AspNetCore.Identity;
using Utfpr.Api.Scan.Domain.Enumeradores;

namespace Utfpr.Api.Scan.Domain.Models.Autenticacao;

public class ApplicationUser : IdentityUser
{
    public string Nome { get; set; }
    public ApplicationUser(string nome)
    {
        Nome = nome;
    }

    public ApplicationUser() { }
}