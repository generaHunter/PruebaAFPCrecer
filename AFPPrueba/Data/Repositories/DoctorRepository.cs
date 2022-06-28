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
    public class DoctorRepository : IDoctorRepository
    {
        private string connectionStrings = String.Empty;
        private readonly IOptions<ConnectionStrings> _GlobalConfiguratios;
        public DoctorRepository(IOptions<ConnectionStrings> globalConfigurations)
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

        public async Task<IdentityResult> AddDoctor(Doctor doctor)
        {
            connectionStrings = _GlobalConfiguratios.Value.DefaultConnection.ToString();
            IdentityResult result = new IdentityResultMock();
            try
            {
                using (SqlConnection con = new SqlConnection(connectionStrings))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_INSERT_DOCTOR", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = doctor.Nombre;

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

        public async Task<List<Doctor>> GetDoctores()
        {
            List<Doctor> doctorList = new List<Doctor>();
            connectionStrings = _GlobalConfiguratios.Value.DefaultConnection.ToString();
            try
            {
                using (SqlConnection con = new SqlConnection(connectionStrings))
                {
                    //
                    using (SqlCommand cmd = new SqlCommand("SP_SELECT_DOCTORES", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        con.Open();
                        SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                        while (rdr.Read())
                        {
                            var doctor = new Doctor();

                            doctor.IdDoctor = Convert.ToInt32(rdr["IdDoctor"]);
                            doctor.Nombre = rdr["Nombre"].ToString();
                            doctorList.Add(doctor);
                        }
                    }
                    //
                }
            }
            catch (Exception e)
            {

                doctorList = null;
            }
            return doctorList;
        }
    }
}
