using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VetPet.Models
{
    public class EspecialidadEntity
    {
        [Key]
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public ICollection<MedicoEntity> Medico { get; set; }

        public ICollection<EspecialidadEntity> Especialidad { get; set;}

        /*
         ESPECIALIDAD
ID ESPECIALIDAD
DESCRIPCIÓN


         */
    }
}
