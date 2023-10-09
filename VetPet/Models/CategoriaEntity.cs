using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VetPet.Models
{
    public class CategoriaEntity
    {
        [Key]
        public int Id { get; set; }

        public string Descripcion { get; set; }

        public ICollection<ProductoEntity> Productos { get; set; }

        /*
         CATEGORIA
ID CATEGORIA
DESCRIPCION


*/
    }
}
