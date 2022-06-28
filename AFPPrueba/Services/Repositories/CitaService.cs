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
    public class CitaService : ICitaService
    {
        private readonly ICitaRepository _citaRepository;
        public CitaService(ICitaRepository citaRepository)
        {
            _citaRepository = citaRepository;
        }
        public async Task<IdentityResult> AddCita(Cita cita)
        {
            return await _citaRepository.AddCita(cita);
        }

        public async Task<IdentityResult> AddDiagnosticoToCita(int IdCita, string Diagnostico)
        {
            return await _citaRepository.AddDiagnosticoToCita(IdCita, Diagnostico);
        }

        public async Task<Cita> GetCitaByCitaId(int CitaId)
        {
            return await _citaRepository.GetCitaByCitaId(CitaId);
        }

        public async Task<List<Cita>> GetCitaByClienteId(int ClienteId)
        {
            return await _citaRepository.GetCitaByClienteId(ClienteId);
        }

        public async Task<List<Cita>> GetCitaByDoctorId(int DoctorId)
        {
            return await _citaRepository.GetCitaByDoctorId(DoctorId);
        }

        public async Task<List<Cita>> GetCitas()
        {
            return await _citaRepository.GetCitas();
        }
    }
}
