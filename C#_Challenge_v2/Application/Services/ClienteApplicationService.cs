using C__Challenge_v2.Application.DTOs;
using C__Challenge_v2.Application.Interfaces;
using C__Challenge_v2.Domain.Entities;
using C__Challenge_v2.Domain.Interfaces;

namespace C__Challenge_v2.Application.Services
{
    public class ClienteApplicationService : IClienteApplicationService
    {

        private readonly IClienteRepository _clienteRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public ClienteApplicationService(IClienteRepository clienteRepository, IUsuarioRepository usuarioRepository)
        {
            _clienteRepository = clienteRepository;
            _usuarioRepository = usuarioRepository;
        }

        public async Task AddAsync(ClienteDto clienteDTO)
        {
            var clienteEntity = new ClienteEntity
            {
                IdCliente = clienteDTO.IdCliente,
                Cep = clienteDTO.Cep,
                TipoPlano = clienteDTO.TipoPlano
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
            var clienteDtos = new List<ClienteDto>();

            foreach (var cliente in clientes)
            {
                var usuario = await _usuarioRepository.GetByIdAsync(cliente.UsuarioId);
                if (usuario != null)
                {
                    var clienteDto = new ClienteDto
                    {
                        IdCliente = cliente.IdCliente,
                        Cep = cliente.Cep,
                        TipoPlano = cliente.TipoPlano,
                        UsuarioId = cliente.UsuarioId,
                        Usuario = new UsuarioDto
                        {
                            IdUsuario = usuario.IdUsuario,
                            CpfCnpj = usuario.CpfCnpj,
                            Nome = usuario.Nome,
                            DataNascimento = usuario.DataNascimento,
                            Email = usuario.Email,
                            Celular = usuario.Celular
                        }
                    };
                    clienteDtos.Add(clienteDto);
                }
            }

            return clienteDtos;
        }

        public async Task<ClienteDto> GetByCpfCnpjAsync(string cpfCnpj)
        {
            var cliente = await _clienteRepository.GetByCpfCnpjAsync(cpfCnpj);
            if (cliente == null) return null;
            return new ClienteDto
            {
                IdCliente = cliente.IdCliente,
                Cep = cliente.Cep,
                TipoPlano = cliente.TipoPlano
            };
        }

        public async Task UpdateAsync(ClienteDto clienteDTO)
        {
            var clienteEntity = new ClienteEntity
            {
                IdCliente = clienteDTO.IdCliente,
                Cep = clienteDTO.Cep,
                TipoPlano = clienteDTO.TipoPlano
            };
            await _clienteRepository.UpdateAsync(clienteEntity);
        }
    }
}
