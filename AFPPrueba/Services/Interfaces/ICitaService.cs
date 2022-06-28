using AFPPrueba.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AFPPrueba.Services.Interfaces
{
    public interface ICitaService
    {
        Task<IdentityResult> AddCita(Cita cita);

        Task<List<Cita>> GetCitas();

        Task<IdentityResult> AddDiagnosticoToCita(int IdCita, string Diagnostico);

        Task<List<Cita>> GetCitaByDoctorId(int DoctorId);
        Task<Cita> GetCitaByCitaId(int CitaId);
        Task<List<Cita>> GetCitaByClienteId(int ClienteId);
    }
}
