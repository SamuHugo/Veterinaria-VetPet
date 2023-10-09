using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VetPet.Models
{
    public class EstadoVacunasEntity
    {
        [Key]
        public int Id { get; set; }

        public int DescripcionVacunas{ get; set;}

        public ICollection<MascotaVacunas> MascotaVacunas { get; set;}
    }
}
