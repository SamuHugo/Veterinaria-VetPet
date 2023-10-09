namespace VetPet.Models
{
    public class MedicacionEntity
    {
        public int Id { get; set; }

        public string DescripcionMedicamento {get; set; }

        public MascotaEntity Mascota { get; set; }
    }
}
