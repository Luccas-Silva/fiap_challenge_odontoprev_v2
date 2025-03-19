using C__Challenge_v2.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace C__Challenge_v2.Infrastructure.AppData
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<UsuarioEntity> Usuario { get; set; }
        public DbSet<ClienteEntity> Cliente { get; set; }
        public DbSet<DentistaEntity> Dentista { get; set; }
        public DbSet<ConsultaEntity> Consulta { get; set; }

    }
}
