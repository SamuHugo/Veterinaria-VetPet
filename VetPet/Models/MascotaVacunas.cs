namespace VetPet.Models
{
    public class MascotaVacunas
    {
        public int MascotaId { get; set; }  

        public int EstadoVacunasId { get; set; }

        public MascotaEntity MascotaEntity { get; set; }

        public EstadoVacunasEntity  EstadoVacunasEntity { get; set; }
    }
}
