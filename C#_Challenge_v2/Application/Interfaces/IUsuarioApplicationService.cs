using C__Challenge_v2.Application.DTOs;

namespace C__Challenge_v2.Application.Interfaces
{
    public interface IUsuarioApplicationService
    {

        Task<IEnumerable<UsuarioDto>> GetAllAsync();
        Task<UsuarioDto> GetByIdAsync(Guid id);
        Task AddAsync(UsuarioDto usuarioDTO);
        Task UpdateAsync(UsuarioDto usuarioDTO);
        Task DeleteAsync(Guid id);
        
    }
}
