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
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;
        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }
        public async Task<IdentityResult> AddDoctor(Doctor doctor)
        {
          return  await _doctorRepository.AddDoctor(doctor);
        }

        public async Task<List<Doctor>> GetDoctores()
        {
            return await _doctorRepository.GetDoctores();
        }
    }
}
