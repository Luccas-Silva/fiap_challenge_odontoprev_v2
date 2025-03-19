using C__Challenge_v2.Domain.Entities;
using C__Challenge_v2.Domain.Interfaces;

namespace C__Challenge_v2.Infrastructure.Data.Repository
{
    public class DentistaRepository : IDentistaRepository
    {
        public Task AddAsync(DentistaEntity dentista)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(string cpfCnpj)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<DentistaEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<DentistaEntity> GetByCpfCnpjAsync(string cpfCnpj)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(DentistaEntity dentista)
        {
            throw new NotImplementedException();
        }
    }
}
