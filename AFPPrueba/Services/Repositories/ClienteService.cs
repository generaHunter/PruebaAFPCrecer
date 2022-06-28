using AFPPrueba.Data.Interfaces;
using AFPPrueba.Models;
using AFPPrueba.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AFPPrueba.Services.Repositories
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public Task<IdentityResult> AddCliente(Cliente cliente)
        {
            return _clienteRepository.AddCliente(cliente);
        }

        public async Task<List<Cliente>> GetClientes()
        {
            return await _clienteRepository.GetClientes();
        }
    }
}
