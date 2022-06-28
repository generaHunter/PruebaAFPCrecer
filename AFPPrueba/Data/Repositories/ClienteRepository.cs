using AFPPrueba.Data.Interfaces;
using AFPPrueba.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.Extensions.Options;
using System.Data.SqlClient;
using System.Data;

namespace AFPPrueba.Data.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private string connectionStrings = String.Empty;
        private readonly IOptions<ConnectionStrings> _GlobalConfiguratios;
        public ClienteRepository(IOptions<ConnectionStrings> globalConfigurations)
        {
            _GlobalConfiguratios = globalConfigurations;
        }

        public class IdentityResultMock : IdentityResult
        {
            public IdentityResultMock(bool succeeded = false)
            {
                this.Succeeded = succeeded;
            }
        }
        public async Task<IdentityResult> AddCliente(Cliente cliente)
        {
            connectionStrings = _GlobalConfiguratios.Value.DefaultConnection.ToString();
            IdentityResult result = new IdentityResultMock();
            try
            {
                using (SqlConnection con = new SqlConnection(connectionStrings))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_INSERT_CLIENTE", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = cliente.Nombre;

                        con.Open();
                    var res = await cmd.ExecuteNonQueryAsync();

                        if (res > 0)
                        {
                            result = new IdentityResultMock(true);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                result = new IdentityResultMock(false);
            }

            return result;
        }

        public async Task<List<Cliente>> GetClientes()
        {
            List<Cliente> clientesList = new List<Cliente>();
            connectionStrings = _GlobalConfiguratios.Value.DefaultConnection.ToString();
            try
            {
                using (SqlConnection con = new SqlConnection(connectionStrings))
                {
                    //
                    using (SqlCommand cmd = new SqlCommand("SP_SELECT_CLIENTES", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        con.Open();
                        SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                        while (rdr.Read())
                        {
                            var cliente = new Cliente();

                            cliente.IdCliente = Convert.ToInt32(rdr["IdCliente"]);
                            cliente.Nombre = rdr["Nombre"].ToString();
                            clientesList.Add(cliente);
                        }
                    }
                    //
                }
            }
            catch (Exception e)
            {

                clientesList = null;
            }
            return clientesList;
        }
    }
}
