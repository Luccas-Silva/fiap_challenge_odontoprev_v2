using C__Challenge_v2.Domain.Entities;

namespace C__Challenge_v2.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<UsuarioEntity>> GetAllAsync();
        Task<UsuarioEntity> GetByIdAsync(Guid id);
        Task AddAsync(UsuarioEntity consulta);
        Task UpdateAsync(UsuarioEntity consulta);
        Task DeleteAsync(Guid id);
        Task DeleteAsync(string cpfCnpj);
    }
}
