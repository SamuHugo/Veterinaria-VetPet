using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VetPet.Models
{
    public class EstadoCivilEntity
    {
        [Key]
        public int Id { get; set; }

        public string Descripcion { get; set; }
        
        public ICollection<MedicoEntity>  Medico { get; set; }
        
    }
}
