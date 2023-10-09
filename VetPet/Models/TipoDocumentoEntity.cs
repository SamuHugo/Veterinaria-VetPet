using System.ComponentModel.DataAnnotations;

namespace VetPet.Models
{
    public class TipoDocumentoEntity
    {
        [Key]
        public int Id { get; set; }

        public string Descripcion { get; set; }

        //public int MedicoId { get; set; }

        public MedicoEntity Medico { get; set; }


        /*
          TIPO DOCUMENTO
ID TIPO DOCUMENTO
DESCRIPCIÓN

         */
    }
}
