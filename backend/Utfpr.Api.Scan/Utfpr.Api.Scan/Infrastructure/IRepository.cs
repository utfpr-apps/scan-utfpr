using Utfpr.Api.Scan.Domain.Models;

namespace Utfpr.Api.Scan.Infrastructure;

public interface IRepository<T> where T : Entity
{
    Task<bool> Adicionar(T entity);
    Task<bool> Deletar(Guid id);
    Task<bool> Atualizar(T entity);
    Task<T?> ObterPorId(Guid id);
    Task<ICollection<T>> ObterTodos();
    Task<bool> Commit();
}