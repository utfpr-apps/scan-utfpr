using System.Net;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Utfpr.Api.Scan.Application.Autenticacao.Interfaces;
using Utfpr.Api.Scan.Application.Autenticacao.ViewModels;
using Utfpr.Api.Scan.Application.Notification;
using Utfpr.Api.Scan.Domain.Models.Autenticacao;
using Utfpr.Api.Scan.Infrastructure.Data;

namespace Utfpr.Api.Scan.Infrastructure.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ApplicationDbContext _context;
    private readonly INotificationContext _notificationContext;

    public UsuarioRepository(ApplicationDbContext context, 
        INotificationContext notificationContext, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _notificationContext = notificationContext;
        _userManager = userManager;
    }


    public async Task<bool> DeletarLogicamenteUsuario(Guid id)
    {
        var registro = await _userManager.FindByIdAsync(id.ToString());
        if (registro == null)
        {
            _notificationContext.AdicionarNotificacoes(HttpStatusCode.NotFound, Mensagens.RegistroNaoEncontrado);
            return false;
        }

        registro.Inativo = true;
        var result = await _userManager.UpdateAsync(registro);
        if (result.Succeeded)
            return true;
        
        _notificationContext.AdicionarNotificacoes(HttpStatusCode.InternalServerError, 
            Mensagens.ErroAoSalvarOperacao);
        return false;
    }

    public async Task<ICollection<ApplicationUser>> ObterUsuariosAdmin()
    {
        return await _userManager
            .Users
            .AsNoTracking()
            .ToListAsync();
    }
}