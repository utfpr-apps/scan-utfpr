using System.Net;
using Microsoft.EntityFrameworkCore;
using Utfpr.Api.Scan.Application.Autenticacao.Interfaces;
using Utfpr.Api.Scan.Application.Notification;
using Utfpr.Api.Scan.Domain.Models.Autenticacao;
using Utfpr.Api.Scan.Infrastructure.Data;

namespace Utfpr.Api.Scan.Infrastructure.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly DbSet<ApplicationUser> _dbSet;
    private readonly ApplicationDbContext _context;
    private readonly INotificationContext _notificationContext;

    public UsuarioRepository(DbSet<ApplicationUser> dbSet, 
        ApplicationDbContext context, INotificationContext notificationContext)
    {
        _dbSet = dbSet;
        _context = context;
        _notificationContext = notificationContext;
    }


    public async Task<bool> DeletarLogicamenteUsuario(Guid id)
    {
        var registro = await _dbSet.FirstOrDefaultAsync(t => t.Id.Equals(id));
        if (registro == null)
        {
            _notificationContext.AdicionarNotificacoes(HttpStatusCode.NotFound, Mensagens.RegistroNaoEncontrado);
            return false;
        }

        registro.Inativo = true;
        _dbSet.Update(registro);
        if (!(await _context.SaveChangesAsync() < 1))
            return true;
        
        _notificationContext.AdicionarNotificacoes(HttpStatusCode.InternalServerError, 
            Mensagens.ErroAoSalvarOperacao);
        return false;
    }
}