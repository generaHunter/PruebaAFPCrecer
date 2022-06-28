using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AFPPrueba.Models
{
    public class Cita
    {
        public int IdCita { get; set; }

        [Required]
        public int IdCliente { get; set; }

        [Required]
        public int IdDoctor { get; set; }

        [Required]
        public DateTime FechaCita { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh:mm}", ApplyFormatInEditMode = true)]

        public string Diagnostico { get; set; } = String.Empty;
    }
}
