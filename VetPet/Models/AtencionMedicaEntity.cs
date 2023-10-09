using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VetPet.Models
{
    public class AtencionMedicaEntity
    {
        [Key]
        public int Id { get; set; }

        public string TituloAtentoMed { get; set; }    

        public ICollection <CitaMedicaEntity> CitaMedica { get; set;}

        public DateTime FechaAtenMed { get; set; }

        public MedicoEntity Medico { get; set; }

        public MascotaEntity Mascota { get; set; }

        public string DescripcionAtenMed { get; set; }
        /*
         ATENCIÓN MÉDICA
ID ATEN MED
TITULO ATEN MED
ID CITA (MOTIVO)
FECHA ATEN MED
ID MEDICO
ID MASCOTA
DECRIPCIÓN


         */
    }
}
