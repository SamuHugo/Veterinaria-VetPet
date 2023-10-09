using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VetPet.Models
{
    public class MarcaEntity
    {
        [Key]
        public int Id { get; set; }

        public string Descripcion { get; set; }

        public ICollection <ProductoEntity> Producto { get; set; }

        /*
         MARCA
ID MARCA
DESCRIPCIÓN



         */
    }
}
