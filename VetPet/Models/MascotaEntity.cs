using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VetPet.Models
{
    public class MascotaEntity
    {
        [Key]
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

        public ICollection<MascotaEntity> Mascota { get; set;}

        public HistorialMedicoEntity HistorialMedico { get; set;}

        public ICollection<MascotaVacunas>  MascotaVacunas { get; set; }

        public ICollection<MascotaEnfermedades> MascotaEnfermedades { get; set; }

        public ICollection<MedicacionEntity> Medicacion { get; set;}

        public ICollection<AtencionMedicaEntity> AtencionMedica { get; set; }
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
