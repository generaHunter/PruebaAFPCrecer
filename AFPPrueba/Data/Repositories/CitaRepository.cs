using AFPPrueba.Data.Interfaces;
using AFPPrueba.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AFPPrueba.Data.Repositories
{
    public class CitaRepository : ICitaRepository
    {
        private string connectionStrings = String.Empty;
        private readonly IOptions<ConnectionStrings> _GlobalConfiguratios;
        public CitaRepository(IOptions<ConnectionStrings> globalConfigurations)
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
        public async Task<IdentityResult> AddCita(Cita cita)
        {
            connectionStrings = _GlobalConfiguratios.Value.DefaultConnection.ToString();
            IdentityResult result = new IdentityResultMock();
            try
            {
                using (SqlConnection con = new SqlConnection(connectionStrings))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_INSERT_CITA", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@idCliente", SqlDbType.Int).Value = cita.IdCliente;
                        cmd.Parameters.Add("@idDoctor", SqlDbType.Int).Value = cita.IdDoctor;
                        cmd.Parameters.Add("@fechaCita", SqlDbType.DateTime).Value = cita.FechaCita;
                        cmd.Parameters.Add("@diagnostico", SqlDbType.VarChar).Value = cita.Diagnostico;

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

        public async Task<IdentityResult> AddDiagnosticoToCita(int IdCita, string Diagnostico)
        {
            connectionStrings = _GlobalConfiguratios.Value.DefaultConnection.ToString();
            IdentityResult result = new IdentityResultMock();
            try
            {
                using (SqlConnection con = new SqlConnection(connectionStrings))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_ADD_DIAGNOSTICO_CITA", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@idCita", SqlDbType.Int).Value = IdCita;
                        cmd.Parameters.Add("@diagnostico", SqlDbType.VarChar).Value = Diagnostico;

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

        public async Task<Cita> GetCitaByCitaId(int CitaId)
        {
            Cita cita = new Cita();
            connectionStrings = _GlobalConfiguratios.Value.DefaultConnection.ToString();
            try
            {
                using (SqlConnection con = new SqlConnection(connectionStrings))
                {
                    //
                    using (SqlCommand cmd = new SqlCommand("SP_SELECT_CITAS_BY_CITAID", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@citaId", SqlDbType.Int).Value = CitaId;

                        con.Open();
                        SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                        while (rdr.Read())
                        {
                            cita.IdCita = Convert.ToInt32(rdr["IdCita"]);
                            cita.IdDoctor = Convert.ToInt32(rdr["IdDoctor"]);
                            cita.IdCliente = Convert.ToInt32(rdr["IdCliente"]);
                            cita.IdCliente = Convert.ToInt32(rdr["IdCliente"]);
                            cita.FechaCita = Convert.ToDateTime(rdr["FechaCita"]);
                            cita.Diagnostico = Convert.ToString(rdr["Diagnostico"]);
                        }
                    }
                    //
                }
            }
            catch (Exception e)
            {

                cita = null;
            }
            return cita;
        }

        public async Task<List<Cita>> GetCitaByClienteId(int ClienteId)
        {
            List<Cita> citaList = new List<Cita>();
            connectionStrings = _GlobalConfiguratios.Value.DefaultConnection.ToString();
            try
            {
                using (SqlConnection con = new SqlConnection(connectionStrings))
                {
                    //
                    using (SqlCommand cmd = new SqlCommand("SP_SELECT_CITAS_BY_CLIENTEID", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@clienteId", SqlDbType.Int).Value = ClienteId;

                        con.Open();
                        SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                        while (rdr.Read())
                        {
                            Cita cita = new Cita();
                            cita.IdCita = Convert.ToInt32(rdr["IdCita"]);
                            cita.IdDoctor = Convert.ToInt32(rdr["IdDoctor"]);
                            cita.IdCliente = Convert.ToInt32(rdr["IdCliente"]);
                            cita.IdCliente = Convert.ToInt32(rdr["IdCliente"]);
                            cita.FechaCita = Convert.ToDateTime(rdr["FechaCita"]);
                            cita.Diagnostico = Convert.ToString(rdr["Diagnostico"]);

                            citaList.Add(cita);
                        }
                    }
                    //
                }
            }
            catch (Exception e)
            {

                citaList = null;
            }
            return citaList;
        }

        public async Task<List<Cita>> GetCitaByDoctorId(int DoctorId)
        {
            List<Cita> citaList = new List<Cita>();
            connectionStrings = _GlobalConfiguratios.Value.DefaultConnection.ToString();
            try
            {
                using (SqlConnection con = new SqlConnection(connectionStrings))
                {
                    //
                    using (SqlCommand cmd = new SqlCommand("SP_SELECT_CITAS_BY_DOCTORID", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@doctorId", SqlDbType.Int).Value = DoctorId;

                        con.Open();
                        SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                        while (rdr.Read())
                        {
                            Cita cita = new Cita();
                            cita.IdCita = Convert.ToInt32(rdr["IdCita"]);
                            cita.IdDoctor = Convert.ToInt32(rdr["IdDoctor"]);
                            cita.IdCliente = Convert.ToInt32(rdr["IdCliente"]);
                            cita.IdCliente = Convert.ToInt32(rdr["IdCliente"]);
                            cita.FechaCita = Convert.ToDateTime(rdr["FechaCita"]);
                            cita.Diagnostico = Convert.ToString(rdr["Diagnostico"]);

                            citaList.Add(cita);
                        }
                    }
                    //
                }
            }
            catch (Exception e)
            {

                citaList = null;
            }
            return citaList;
        }

        public async Task<List<Cita>> GetCitas()
        {
            List<Cita> citaList = new List<Cita>();
            connectionStrings = _GlobalConfiguratios.Value.DefaultConnection.ToString();
            try
            {
                using (SqlConnection con = new SqlConnection(connectionStrings))
                {
                    //
                    using (SqlCommand cmd = new SqlCommand("SP_SELECT_CITAS", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        con.Open();
                        SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                        while (rdr.Read())
                        {
                            Cita cita = new Cita();
                            cita.IdCita = Convert.ToInt32(rdr["IdCita"]);
                            cita.IdDoctor = Convert.ToInt32(rdr["IdDoctor"]);
                            cita.IdCliente = Convert.ToInt32(rdr["IdCliente"]);
                            cita.IdCliente = Convert.ToInt32(rdr["IdCliente"]);
                            cita.FechaCita = Convert.ToDateTime(rdr["FechaCita"]);
                            cita.Diagnostico = Convert.ToString(rdr["Diagnostico"]);

                            citaList.Add(cita);
                        }
                    }
                    //
                }
            }
            catch (Exception e)
            {

                citaList = null;
            }
            return citaList;
        }
    }
}
