using System.Collections.Generic;

namespace VetPet.Models
{
    public class EnfermedadesEntity
    {
        public int Id { get; set; }
        public string DescripcionEnferm {get; set;}

        public ICollection<MascotaEnfermedades> MascotaEnfermedades { get; set;}
    }
}
