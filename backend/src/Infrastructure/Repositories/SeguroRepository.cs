using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class SeguroRepository : ISeguroRepository
    {
        private readonly SeguroContext _context;

        public SeguroRepository(SeguroContext context)
        {
            _context = context;
        }

        public async Task<Seguro> AdicionarAsync(Seguro seguro)
        {
            _context.Seguros.Add(seguro);
            await _context.SaveChangesAsync();
            return seguro;
        }

        public async Task<Seguro> ObterPorIdAsync(Guid id)
        {
            return await _context.Seguros
                .Include(s => s.Veiculo)
                .Include(s => s.Segurado)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<Seguro>> ObterTodosAsync()
        {
            return await _context.Seguros
                .Include(s => s.Veiculo)
                .Include(s => s.Segurado)
                .ToListAsync();
        }
    }
}

