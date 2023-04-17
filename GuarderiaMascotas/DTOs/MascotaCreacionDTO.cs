using System.ComponentModel.DataAnnotations;

namespace GuarderiaMascotas.DTOs
{
    public class MascotaCreacionDTO
    {
        [Required]
        [StringLength(40)]
        public string nombre { get; set; }
        [StringLength(40)]
        public string tipo { get; set; }
        [StringLength(40)]
        public string raza { get; set; }
        public int edad { get; set; }
    }
}
