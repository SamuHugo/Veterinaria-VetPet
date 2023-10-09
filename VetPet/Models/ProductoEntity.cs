using System.ComponentModel.DataAnnotations;

namespace VetPet.Models
{
    public class ProductoEntity
    {
        [Key]
        public int Id { get; set; }
        public string Imagen { get; set; }
        public string Nonbre { get; set; }

        public string DescripcionProd { get; set; }

        public string CaracteristicasProd { get; set; } 

        public MarcaEntity Marca { get; set; }  

        public CategoriaEntity Categoria { get; set; }

        public TipoAnimalEntity TipoAnimal { get; set; }

        public string SKU { get; set; } 

        public double Precio { get; set; }  

        public int Stock { get; set; }
        /*
         PRODUCTO/ITEM
ID ITEM
IMAGEN
NOMBRE
DESCRIPCIÓN
CARACTERISTICAS
ID MARCA
ID CATEGORIA
ID TIPO ANIMAL
SKU (CODIGO DE ITEM)
PRECIO
STOCK
*/
    }
}
