using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VetPet.Models
{
    public class TipoAnimalEntity
    {
        [Key]
        public int Id { get; set; }

        public string Descripcion { get; set; }

        public ICollection <ProductoEntity> Producto { get; set; }
        /*
         TIPO ANIMAL
ID TIPO ANIMAL
DESCRIPCIÓN

*/
    }
}
