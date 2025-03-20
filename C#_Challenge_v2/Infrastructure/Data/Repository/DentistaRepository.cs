using C__Challenge_v2.Domain.Entities;
using C__Challenge_v2.Domain.Interfaces;
using C__Challenge_v2.Infrastructure.AppData;
using Microsoft.EntityFrameworkCore;

namespace C__Challenge_v2.Infrastructure.Data.Repository
{
    public class DentistaRepository : IDentistaRepository
    {

        private readonly ApplicationContext _context;

        public DentistaRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task AddAsync(DentistaEntity dentista)
        {
            await _context.Dentista.AddAsync(dentista);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string cpfCnpj)
        {
            var dentista = await _context.Dentista.FirstOrDefaultAsync(d => d.Usuario.CpfCnpj == cpfCnpj);
            if (dentista != null)
            {
                _context.Dentista.Remove(dentista);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<DentistaEntity>> GetAllAsync()
        {
            return await _context.Dentista.OrderBy(d => d.IdDentista).ToListAsync();
        }

        public async Task<DentistaEntity> GetByCpfCnpjAsync(string cpfCnpj)
        {
            return await _context.Dentista.FirstOrDefaultAsync(d => d.Usuario.CpfCnpj == cpfCnpj);
        }

        public async Task UpdateAsync(DentistaEntity dentista)
        {
            _context.Dentista.Update(dentista);
            await _context.SaveChangesAsync(); ;
        }

    }
}
