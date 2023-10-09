using System.ComponentModel.DataAnnotations;

namespace VetPet.Models
{
    public class GeneroEntity
    {
        [Key]
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public MedicoEntity Medico { get; set; }
        /*
         GENERO
ID GENERO
DESCRIPCIÓN



         */
    }
}
