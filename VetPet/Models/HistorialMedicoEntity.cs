using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VetPet.Models
{
    public class HistorialMedicoEntity
    {
        [Key]
        public int  Id { get; set; }

        public ICollection<CitaMedicaEntity> CitaMedica { get; set; }   

        public ICollection<MedicoEntity> Medico { get; set; }
        public ICollection<MascotaEntity> Mascota { get; set;}
        /*
         HISTORIAL MÉDICO
ID HISTORIAL MED
ID CITA
ID MEDICO
ID MASCOTA


*/
    }

}
