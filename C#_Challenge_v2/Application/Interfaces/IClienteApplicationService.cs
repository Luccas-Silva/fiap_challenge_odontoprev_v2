using C__Challenge_v2.Application.DTOs;

namespace C__Challenge_v2.Application.Interfaces
{
    public interface IClienteApplicationService
    {
        Task<IEnumerable<ClienteDto>> GetAllAsync();
        Task<ClienteDto> GetByCpfCnpjAsync(string cpfCnpj);
        Task AddAsync(ClienteDto cliente);
        Task UpdateAsync(ClienteDto cliente);
        Task DeleteAsync(string cpfCnpj);
    }
}
