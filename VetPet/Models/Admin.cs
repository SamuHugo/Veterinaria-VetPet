using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VetPet.Models
{
    public class Admin
    {
        [Key]
        [Column("adminId")]
        public int Id { get; set; }
        public string nombres { get; set; }
        public string apePaterno { get; set; }
        public string apeMaterno { get; set;}
        public string correo { get; set;}
        public string contraseña { get; set;}
    }
}
