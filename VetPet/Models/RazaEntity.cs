using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VetPet.Models
{
    public class RazaEntity
    {
        [Key]
        public int Id { get; set; }

        public string Descripcion { get; set; }

        public ICollection<MascotaEntity> Mascota { get; set;}

        /*
        ID RAZA
ID RAZA
DESCRIPCION

        */

    }
}
