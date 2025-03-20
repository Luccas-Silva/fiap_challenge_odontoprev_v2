using C__Challenge_v2.Application.DTOs;
using C__Challenge_v2.Application.Interfaces;
using C__Challenge_v2.Domain.Entities;
using C__Challenge_v2.Domain.Interfaces;

namespace C__Challenge_v2.Application.Services
{
    public class ClienteApplicationService : IClienteApplicationService
    {

        private readonly IClienteRepository _clienteRepository;

        public ClienteApplicationService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task AddAsync(ClienteDto clienteDTO)
        {
            var clienteEntity = new ClienteEntity
            {
                IdCliente = clienteDTO.IdCliente,
                Cep = clienteDTO.Cep,
                TipoPlano = clienteDTO.TipoPlano,
                UsuarioId = clienteDTO.CpfCnpj
            };
            await _clienteRepository.AddAsync(clienteEntity);
        }

        public async Task DeleteAsync(string cpfCnpj)
        {
            var clienteEntity = await _clienteRepository.GetByCpfCnpjAsync(cpfCnpj);
            if (clienteEntity != null)
            {
                await _clienteRepository.DeleteAsync(clienteEntity.Usuario.CpfCnpj);
            }
        }

        public async Task<IEnumerable<ClienteDto>> GetAllAsync()
        {
            var clientes = await _clienteRepository.GetAllAsync();
            return clientes.Select(cliente => new ClienteDto
            {
                IdCliente = cliente.IdCliente,
                Cep = cliente.Cep,
                TipoPlano = cliente.TipoPlano,
                CpfCnpj = cliente.UsuarioId
            });
        }

        public async Task<ClienteDto> GetByCpfCnpjAsync(string cpfCnpj)
        {
            var cliente = await _clienteRepository.GetByCpfCnpjAsync(cpfCnpj);
            if (cliente == null) return null;
            return new ClienteDto
            {
                IdCliente = cliente.IdCliente,
                Cep = cliente.Cep,
                TipoPlano = cliente.TipoPlano,
                CpfCnpj = cliente.UsuarioId
            };
        }

        public async Task UpdateAsync(ClienteDto clienteDTO)
        {
            var clienteEntity = new ClienteEntity
            {
                IdCliente = clienteDTO.IdCliente,
                Cep = clienteDTO.Cep,
                TipoPlano = clienteDTO.TipoPlano,
                UsuarioId = clienteDTO.CpfCnpj
            };
            await _clienteRepository.UpdateAsync(clienteEntity);
        }
    }
}
