namespace VetPet.Models
{
    public class MascotaEnfermedades
    {

        public int MascotaId { get; set; }

        public int EnfermedadesId { get; set; }

        public MascotaEntity MascotaEntity { get; set; }

        public EnfermedadesEntity EnfermedadesEntity { get;set; }
    }
}
