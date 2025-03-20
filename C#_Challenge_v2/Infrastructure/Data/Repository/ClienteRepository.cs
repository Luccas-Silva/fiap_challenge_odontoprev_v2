using C__Challenge_v2.Domain.Entities;
using C__Challenge_v2.Domain.Interfaces;
using C__Challenge_v2.Infrastructure.AppData;
using Microsoft.EntityFrameworkCore;


namespace C__Challenge_v2.Infrastructure.Data.Repository
{
    public class ClienteRepository : IClienteRepository
    {

        private readonly ApplicationContext _context;

        public ClienteRepository(ApplicationContext context) 
        { 
            _context = context;
        }

        public async Task AddAsync(ClienteEntity cliente)
        {
            await _context.Cliente.AddAsync(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string cpfCnpj)
        {
            var cliente = await _context.Cliente.FirstOrDefaultAsync(c => c.Usuario.CpfCnpj == cpfCnpj);
            if (cliente != null)
            {
                _context.Cliente.Remove(cliente);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(ClienteEntity cliente)
        {
            _context.Cliente.Remove(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ClienteEntity>> GetAllAsync()
        {
            return await _context.Cliente.OrderBy(c => c.IdCliente).ToListAsync(); ;
        }

        public async Task<ClienteEntity> GetByCpfCnpjAsync(string cpfCnpj)
        {
            return await _context.Cliente.FirstOrDefaultAsync(c => c.Usuario.CpfCnpj == cpfCnpj);
        }

        public async Task UpdateAsync(ClienteEntity cliente)
        {
            _context.Cliente.Update(cliente);
            await _context.SaveChangesAsync(); ;
        }
    }
}
