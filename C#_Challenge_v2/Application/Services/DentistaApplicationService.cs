using C__Challenge_v2.Application.DTOs;
using C__Challenge_v2.Application.Interfaces;
using C__Challenge_v2.Domain.Entities;
using C__Challenge_v2.Domain.Interfaces;

namespace C__Challenge_v2.Application.Services
{
    public class DentistaApplicationService : IDentistaApplicationService
    {
        private readonly IDentistaRepository _dentistaRepository;

        public DentistaApplicationService(IDentistaRepository dentistaRepository)
        {
            _dentistaRepository = dentistaRepository;
        }

        public async Task AddAsync(DentistaDto dentistaDTO)
        {
            var dentistaEntity = new DentistaEntity
            {
                IdDentista = dentistaDTO.IdDentista,
                CepClinica = dentistaDTO.CepClinica,
                NomeClinica = dentistaDTO.NomeClinica,
                TipoClinica = dentistaDTO.TipoClinica,
                AlvaraFuncionamento = dentistaDTO.AlvaraFuncionamento,
                SiteRedesSocial = dentistaDTO.SiteRedesSocial,
                UsuarioId = dentistaDTO.UsuarioId
            };
            await _dentistaRepository.AddAsync(dentistaEntity);
        }

        public async Task DeleteAsync(string cpfCnpj)
        {
            var dentistaEntity = await _dentistaRepository.GetByCpfCnpjAsync(cpfCnpj);
            if (dentistaEntity != null)
            {
                await _dentistaRepository.DeleteAsync(cpfCnpj);
            }
        }

        public async Task<IEnumerable<DentistaDto>> GetAllAsync()
        {
            var dentistas = await _dentistaRepository.GetAllAsync();
            return dentistas.Select(dentista => new DentistaDto
            {
                IdDentista = dentista.IdDentista,
                CepClinica = dentista.CepClinica,
                NomeClinica = dentista.NomeClinica,
                TipoClinica = dentista.TipoClinica,
                AlvaraFuncionamento = dentista.AlvaraFuncionamento,
                SiteRedesSocial = dentista.SiteRedesSocial,
                UsuarioId = dentista.UsuarioId
            });
        }

        public async Task<DentistaDto> GetByCpfCnpjAsync(string cpfCnpj)
        {
            var dentista = await _dentistaRepository.GetByCpfCnpjAsync(cpfCnpj);
            if (dentista == null) return null;
            return new DentistaDto
            {
                IdDentista = dentista.IdDentista,
                CepClinica = dentista.CepClinica,
                NomeClinica = dentista.NomeClinica,
                TipoClinica = dentista.TipoClinica,
                AlvaraFuncionamento = dentista.AlvaraFuncionamento,
                SiteRedesSocial = dentista.SiteRedesSocial,
                UsuarioId = dentista.UsuarioId
            };
        }

        public async Task UpdateAsync(DentistaDto dentistaDTO)
        {
            var dentistaEntity = new DentistaEntity
            {
                IdDentista = dentistaDTO.IdDentista,
                CepClinica = dentistaDTO.CepClinica,
                NomeClinica = dentistaDTO.NomeClinica,
                TipoClinica = dentistaDTO.TipoClinica,
                AlvaraFuncionamento = dentistaDTO.AlvaraFuncionamento,
                SiteRedesSocial = dentistaDTO.SiteRedesSocial,
                UsuarioId = dentistaDTO.UsuarioId
            };
            await _dentistaRepository.UpdateAsync(dentistaEntity);
        }
    }
}
