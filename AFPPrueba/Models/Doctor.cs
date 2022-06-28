using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AFPPrueba.Models
{
    public class Doctor
    {
        public int IdDoctor { get; set; }

        [Required]
        public string Nombre { get; set; }
    }
}
