using System.ComponentModel.DataAnnotations;

namespace VetPet.Models
{
    public class EstadoCivilEntity
    {
        [Key]
        public int Id { get; set; }

        public string Descripcion { get; set; }
        
        public MedicoEntity Medico { get; set; }
        /*
          ESTADO CIVIL
ID ESTADO CIVIL
DESCRIPCIÓN


         */
    }
}
