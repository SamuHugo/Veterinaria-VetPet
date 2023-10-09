using System;
using System.Collections.Generic;

namespace VetPet.Models
{
    public class MascotaEntity
    {


        public int Id { get; set; }
        public string Imagen { get; set; }
        public string Nombre { get; set; }
        public string Apodo { get; set; }

        public RazaEntity Raza { get; set; }

        public ICollection<GeneroEntity> Genero { get; set; }

        public DateTime FechaAdopcion { get; set; }
        public string Descripcion { get; set; } 

        public string Comentario { get; set;}

        public UsuarioEntity Usuario { get; set; }
        /*
          MASCOTA
ID MASCOTA
IMAGEN
NOMBRE
APODO
ID RAZA
ID SEXO
FECHA ADOPCIÓN
DESCRIPCIÓN
ID ESTADO VACUNAS
ID TIPO ENFERMEDAD
ID ESTADO MEDICACIÓN
ID PROXIMA ATENCIÓN
COMENTARIO
ID USUARIO

         */
    }
}
