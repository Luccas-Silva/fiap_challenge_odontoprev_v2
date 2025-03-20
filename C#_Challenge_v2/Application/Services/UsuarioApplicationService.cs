using C__Challenge_v2.Application.DTOs;
using C__Challenge_v2.Application.Interfaces;
using C__Challenge_v2.Domain.Entities;
using C__Challenge_v2.Domain.Interfaces;

namespace C__Challenge_v2.Application.Services
{
    public class UsuarioApplicationService : IUsuarioApplicationService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioApplicationService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task AddAsync(UsuarioDto usuarioDTO)
        {
            var usuarioEntity = new UsuarioEntity
            {
                IdUsuario = usuarioDTO.IdUsuario,
                CpfCnpj = usuarioDTO.CpfCnpj,
                Nome = usuarioDTO.Nome,
                DataNascimento = usuarioDTO.DataNascimento,
                Email = usuarioDTO.Email,
                Celular = usuarioDTO.Celular
            };
            await _usuarioRepository.AddAsync(usuarioEntity);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _usuarioRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<UsuarioDto>> GetAllAsync()
        {
            var usuarios = await _usuarioRepository.GetAllAsync();
            return usuarios.Select(usuario => new UsuarioDto
            {
                IdUsuario = usuario.IdUsuario,
                CpfCnpj = usuario.CpfCnpj,
                Nome = usuario.Nome,
                DataNascimento = usuario.DataNascimento,
                Email = usuario.Email,
                Celular = usuario.Celular
            });
        }

        public async Task<UsuarioDto> GetByIdAsync(Guid id)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);
            if (usuario == null) return null;
            return new UsuarioDto
            {
                IdUsuario = usuario.IdUsuario,
                CpfCnpj = usuario.CpfCnpj,
                Nome = usuario.Nome,
                DataNascimento = usuario.DataNascimento,
                Email = usuario.Email,
                Celular = usuario.Celular
            };
        }

        public async Task UpdateAsync(UsuarioDto usuarioDTO)
        {
            var usuarioEntity = new UsuarioEntity
            {
                IdUsuario = usuarioDTO.IdUsuario,
                CpfCnpj = usuarioDTO.CpfCnpj,
                Nome = usuarioDTO.Nome,
                DataNascimento = usuarioDTO.DataNascimento,
                Email = usuarioDTO.Email,
                Celular = usuarioDTO.Celular
            };
            await _usuarioRepository.UpdateAsync(usuarioEntity);
        }
    }
}
