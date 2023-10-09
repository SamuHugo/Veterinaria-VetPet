using System;
using System.ComponentModel.DataAnnotations;

namespace VetPet.Models
{
    public class CitaMedicaEntity
    {
        [Key]
        public int Id { get; set; }
        public string Motivo { get; set; }
        public SedeClinicaEntity SedeClinica { get; set; }

        public EspecialidadEntity Especialidad { get; set; }

        public MedicoEntity Medico { get; set; }
        public UsuarioEntity Usuario { get; set; }  
        public MascotaEntity Mascota { get; set; } 

        public DateTime FechaCita { get; set; }

        public string TelefContacto { get; set; }
        public string DetalleCita { get; set; }

        public AtencionMedicaEntity AtencionMedica { get; set;}

        public HistorialMedicoEntity HistorialMedica { get; set;}


        /*
         CITA MÉDICA
ID CITA
MOTIVO
ID SEDE
ID ESPECIALIDAD
ID MEDICO
ID USUARIO
MASCOTA
FECHA
TELEFONO CONTACTO
DETALLE CITA
*/

    }
}
