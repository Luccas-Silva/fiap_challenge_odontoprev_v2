using C__Challenge_v2.Domain.Entities;

namespace C__Challenge_v2.Domain.Interfaces
{
    public interface IDentistaRepository
    {
        Task<IEnumerable<DentistaEntity>> GetAllAsync();
        Task<DentistaEntity> GetByCpfCnpjAsync(string cpfCnpj);
        Task AddAsync(DentistaEntity dentista);
        Task UpdateAsync(DentistaEntity dentista);
        Task DeleteAsync(string cpfCnpj);
    }
}
