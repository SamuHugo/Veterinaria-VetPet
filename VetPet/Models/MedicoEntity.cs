using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VetPet.Models
{
    public class MedicoEntity
    {
        [Key]
        public int Id { get; set; }

        public string Imagen { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set;}

        public ICollection<TipoDocumentoEntity> TipoDocumentos { get; set; }

        public string NumeroDocumento { get; set; }

        public string Telefono1 { get; set; }
        public string Telefono2 { get; set; }
        public string Direccion { get; set; }

        public int SedeClinicaId { get; set; }

        public SedeClinicaEntity SedeClinicaEntity { get; set; }

        public ICollection<GeneroEntity> Genero { get; set; }    
        
        public DateTime FechaNacimiento { get; set; }

        public ICollection<EstadoCivilEntity> EstadoCivil { get; set; }

        public EspecialidadEntity EspecialidadEntity { get; set;}

        public string DescripProfesional { get; set; }
        public string Correo { get; set; }  
        public string Contrasena { get; set; }

        public ICollection<CitaMedicaEntity> CitaMedica { get; set;}

        public ICollection<AtencionMedicaEntity> AtencionMedica { get;set; }

        public HistorialMedicoEntity HistorialMedico { get; set;}



/*MEDICO 
ID MEDICO
IMAGEN
NOMBRES
APELLIDO
ID TIPO DOCUMENTO
N° DOCUMENTO
TELEFONO 1
TELEFONO 2
DIRECCIÓN
ID SEDE CLINICA
ID GENERO
FECHA DE NACIMIENTO
ID ESTADO CIVIL
ID ESPECIALIDAD
DESCRIPCIÓN PROFESIONAL
CORREO
CONTRASEÑA
*/
    }
}
