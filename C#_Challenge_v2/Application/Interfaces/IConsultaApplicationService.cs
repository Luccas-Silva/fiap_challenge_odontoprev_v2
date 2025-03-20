using C__Challenge_v2.Application.DTOs;

namespace C__Challenge_v2.Application.Interfaces
{
    public interface IConsultaApplicationService
    {
        Task<IEnumerable<ConsultaDto>> GetAllAsync();
        Task<ConsultaDto> GetByIdAsync(Guid id);
        Task AddAsync(ConsultaDto consulta);
        Task UpdateAsync(ConsultaDto consulta);
        Task DeleteAsync(Guid id);
    }
}
