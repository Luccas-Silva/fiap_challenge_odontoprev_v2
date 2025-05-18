using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    internal class ClienteApplicationTest
    {
        private readonly Mock<IClienteRepository> _clienteRepository;

        private readonly ClienteApplication _clienteApplication;

        public ClienteApplicationTest()
        {
            _clienteRepository = new Mock<IClienteRepository>();

            _clienteApplication = new ClienteApplication(_clienteRepository.Object);
        }
    }
}
