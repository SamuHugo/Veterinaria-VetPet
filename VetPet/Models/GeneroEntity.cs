using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VetPet.Models
{
    public class GeneroEntity
    {
        [Key]
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public ICollection<MedicoEntity>  Medico { get; set; }
        
        public ICollection<MascotaEntity> Mascota { get; set; }

        public ICollection<UsuarioEntity> Usuario { get; set; }
       
    }
}
