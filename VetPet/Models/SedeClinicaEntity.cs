using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VetPet.Models
{
    public class SedeClinicaEntity
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }

        public ICollection<MedicoEntity> Medico { get; set; }
        public ICollection<CitaMedicaEntity> CitaMedica { get; set; }
        /*
        SEDE CLINICA
ID SEDE
NOMBRE
DIRECCIÓN

         */
    }
}
