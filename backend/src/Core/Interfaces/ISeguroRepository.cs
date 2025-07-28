using Core.Entities;

namespace Core.Interfaces
{
    public interface ISeguroRepository
    {
        Task<Seguro> AdicionarAsync(Seguro seguro);
        Task<Seguro> ObterPorIdAsync(Guid id);
        Task<IEnumerable<Seguro>> ObterTodosAsync();
    }
}

