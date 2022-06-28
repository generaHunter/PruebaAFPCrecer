using AFPPrueba.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AFPPrueba.Services.Interfaces
{
    public interface IDoctorService
    {
        Task<IdentityResult> AddDoctor(Doctor doctor);

        Task<List<Doctor>> GetDoctores();
    }
}
