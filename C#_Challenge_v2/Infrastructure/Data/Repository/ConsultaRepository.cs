using C__Challenge_v2.Domain.Entities;
using C__Challenge_v2.Domain.Interfaces;
using C__Challenge_v2.Infrastructure.AppData;
using Microsoft.EntityFrameworkCore;

namespace C__Challenge_v2.Infrastructure.Data.Repository
{
    public class ConsultaRepository : IConsultaRepository
    {

        private readonly ApplicationContext _context;

        public ConsultaRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task AddAsync(ConsultaEntity consulta)
        {
            await _context.Consulta.AddAsync(consulta);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var consulta = await _context.Consulta.FindAsync(id);
            if (consulta != null)
            {
                _context.Consulta.Remove(consulta);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ConsultaEntity>> GetAllAsync()
        {
            return await _context.Consulta.OrderBy(c => c.IdConsulta).ToListAsync();
        }

        public async Task<ConsultaEntity> GetByIdAsync(Guid id)
        {
            return await _context.Consulta.FindAsync(id);
        }

        public async Task UpdateAsync(ConsultaEntity consulta)
        {
            _context.Consulta.Update(consulta);
            await _context.SaveChangesAsync();
        }
    }
}
