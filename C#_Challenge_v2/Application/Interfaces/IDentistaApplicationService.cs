using C__Challenge_v2.Application.DTOs;

namespace C__Challenge_v2.Application.Interfaces
{
    public interface IDentistaApplicationService
    {
        Task<IEnumerable<DentistaDto>> GetAllAsync();
        Task<DentistaDto> GetByCpfCnpjAsync(string cpfCnpj);
        Task AddAsync(DentistaDto dentista);
        Task UpdateAsync(DentistaDto dentista);
        Task DeleteAsync(string cpfCnpj);
    }
}
