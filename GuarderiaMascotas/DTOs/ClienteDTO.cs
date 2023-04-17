using System.ComponentModel.DataAnnotations;

namespace GuarderiaMascotas.DTOs
{
    public class ClienteDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        [StringLength(10)]
        public string Identificacion { get; set; }
        [StringLength(30)]
        public string Direccion { get; set; }
        [StringLength(10)]
        public string Telefono { get; set; }
    }
}
