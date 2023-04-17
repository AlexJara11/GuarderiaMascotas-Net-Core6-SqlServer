using System.ComponentModel.DataAnnotations;

namespace GuarderiaMascotas.Entidades
{
    public class Cliente
    {
        public int Id { get; set; }
        [Required]
        [StringLength(300)]
        public string Nombre { get; set; }
        public int Edad { get; set; }
        [StringLength(10)]
        public string Identificacion { get; set;}
        [StringLength(30)]
        public string Direccion { get; set;}
        [StringLength(10)]
        public string Telefono { get; set;}

        public List<MascotasClientes> MascotasClientes { get; set; }

    }
}
