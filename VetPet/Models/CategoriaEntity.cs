using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VetPet.Models
{
    public class CategoriaEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int Id { get; set; }

        public string Descripcion { get; set; }

        public ICollection<ProductoEntity> Producto { get; set; }

        /*
         CATEGORIA
ID CATEGORIA
DESCRIPCION


*/
    }
}
