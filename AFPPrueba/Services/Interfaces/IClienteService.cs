using AFPPrueba.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AFPPrueba.Services.Interfaces
{
    public interface IClienteService
    {
        Task<IdentityResult> AddCliente(Cliente cliente);

        Task<List<Cliente>> GetClientes();
    }
}
