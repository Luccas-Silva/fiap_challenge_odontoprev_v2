using C__Challenge_v2.Domain.Entities;
using C__Challenge_v2.Domain.Interfaces;
using C__Challenge_v2.Infrastructure.AppData;
using Microsoft.EntityFrameworkCore;

namespace C__Challenge_v2.Infrastructure.Data.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationContext _context;

        public UsuarioRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task AddAsync(UsuarioEntity usuario)
        {
            await _context.Usuario.AddAsync(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuario.Remove(usuario);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<UsuarioEntity>> GetAllAsync()
        {
            return await _context.Usuario.ToListAsync();
        }

        public async Task<UsuarioEntity> GetByIdAsync(Guid id)
        {
            return await _context.Usuario.FindAsync(id);
        }

        public async Task UpdateAsync(UsuarioEntity usuario)
        {
            _context.Usuario.Update(usuario);
            await _context.SaveChangesAsync();
        }
    }
}
