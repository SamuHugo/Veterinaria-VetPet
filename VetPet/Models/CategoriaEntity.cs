using System.ComponentModel.DataAnnotations;

namespace VetPet.Models
{
    public class CategoriaEntity
    {
        [Key]
        public int Id { get; set; }

        public string Descripcion { get; set; }

        /*
         CATEGORIA
ID CATEGORIA
DESCRIPCION


*/
    }
}
