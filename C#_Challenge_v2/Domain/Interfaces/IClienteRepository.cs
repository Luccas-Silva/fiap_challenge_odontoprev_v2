using C__Challenge_v2.Domain.Entities;

namespace C__Challenge_v2.Domain.Interfaces
{
    public interface IClienteRepository
    {
        Task<IEnumerable<ClienteEntity>> GetAllAsync();
        Task<ClienteEntity> GetByCpfCnpjAsync(string cpfCnpj);
        Task AddAsync(ClienteEntity cliente);
        Task UpdateAsync(ClienteEntity cliente);
        Task DeleteAsync(string cpfCnpj);

    }
}
