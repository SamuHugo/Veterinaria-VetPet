using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VetPet.Models
{
    public class UsuarioEntity
    {
        [Key]
        public int Id { get; set; }
        public string Imagen { get; set; }
        public string Apellido { get; set; }

        public ICollection<TipoDocumentoEntity> TipoDocumento { get; set;}

        public string NumeroDocumento { get; set; } 

        public string Telefono { get; set; }    

        public string Direccion { get; set; }
        public ICollection<GeneroEntity> Genero { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Correo { get; set; }  
        public string Contrasena { get; set; }

        public ICollection<MascotaEntity> Mascota { get; set;}

        public ICollection<CitaMedicaEntity> CitaMedica { get; set;}
        /*
         USUARIO
ID USUARIO
IMAGEN
NOMBRES
APELLIDO
ID TIPO DOCUMENTO
N° DOCUMENTO
TELEFONO
DIRECCIÓN
ID GENERO
FECHA DE NACIMIENTO
CORREO
CONTRASEÑA
*/
    }
}
