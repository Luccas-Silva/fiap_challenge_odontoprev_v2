using C__Challenge_v2.Domain.Entities;

namespace C__Challenge_v2.Domain.Interfaces
{
    public interface IConsultaRepository
    {
        Task<IEnumerable<ConsultaEntity>> GetAllAsync();
        Task<ConsultaEntity> GetByIdAsync(Guid id);
        Task AddAsync(ConsultaEntity consulta);
        Task UpdateAsync(ConsultaEntity consulta);
        Task DeleteAsync(Guid id);

    }
}
