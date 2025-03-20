using C__Challenge_v2.Application.DTOs;
using C__Challenge_v2.Application.Interfaces;
using C__Challenge_v2.Domain.Entities;
using C__Challenge_v2.Domain.Interfaces;

namespace C__Challenge_v2.Application.Services
{
    public class ConsultaApplicationService : IConsultaApplicationService
    {
        private readonly IConsultaRepository _consultaRepository;

        public ConsultaApplicationService(IConsultaRepository consultaRepository)
        {
            _consultaRepository = consultaRepository;
        }

        public async Task AddAsync(ConsultaDto consultaDTO)
        {
            var consultaEntity = new ConsultaEntity
            {
                IdConsulta = consultaDTO.IdConsulta,
                DateConsulta = consultaDTO.DateConsulta,
                TipoConsulta = consultaDTO.TipoConsulta,
                ValorMedioConsulta = consultaDTO.ValorMedioConsulta,
                DentistaCpfCnpj = consultaDTO.DentistaCpfCnpj,
                ClienteCpfCnpj = consultaDTO.ClienteCpfCnpj
            };
            await _consultaRepository.AddAsync(consultaEntity);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _consultaRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ConsultaDto>> GetAllAsync()
        {
            var consultas = await _consultaRepository.GetAllAsync();
            return consultas.Select(consulta => new ConsultaDto
            {
                IdConsulta = consulta.IdConsulta,
                DateConsulta = consulta.DateConsulta,
                TipoConsulta = consulta.TipoConsulta,
                ValorMedioConsulta = consulta.ValorMedioConsulta,
                DentistaCpfCnpj = consulta.DentistaCpfCnpj,
                ClienteCpfCnpj = consulta.ClienteCpfCnpj
            });
        }

        public async Task<ConsultaDto> GetByIdAsync(Guid id)
        {
            var consulta = await _consultaRepository.GetByIdAsync(id);
            if (consulta == null) return null;
            return new ConsultaDto
            {
                IdConsulta = consulta.IdConsulta,
                DateConsulta = consulta.DateConsulta,
                TipoConsulta = consulta.TipoConsulta,
                ValorMedioConsulta = consulta.ValorMedioConsulta,
                DentistaCpfCnpj = consulta.DentistaCpfCnpj,
                ClienteCpfCnpj = consulta.ClienteCpfCnpj
            };
        }

        public async Task UpdateAsync(ConsultaDto consultaDTO)
        {
            var consultaEntity = new ConsultaEntity
            {
                IdConsulta = consultaDTO.IdConsulta,
                DateConsulta = consultaDTO.DateConsulta,
                TipoConsulta = consultaDTO.TipoConsulta,
                ValorMedioConsulta = consultaDTO.ValorMedioConsulta,
                DentistaCpfCnpj = consultaDTO.DentistaCpfCnpj,
                ClienteCpfCnpj = consultaDTO.ClienteCpfCnpj
            };
            await _consultaRepository.UpdateAsync(consultaEntity);
        }
    }
}
