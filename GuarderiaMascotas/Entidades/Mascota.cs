using System.ComponentModel.DataAnnotations;

namespace GuarderiaMascotas.Entidades
{
    public class Mascota
    {
        public int Id { get; set; }
        [Required]
        [StringLength(40)]
        public string nombre { get; set; }
        [StringLength(40)]
        public string tipo { get; set; }
        [StringLength(40)]
        public string raza { get; set; }
        public int edad { get; set; }
        public List<MascotasClientes> MascotasClientes { get; set; }
    }
}
