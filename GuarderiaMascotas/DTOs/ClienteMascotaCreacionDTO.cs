using System.ComponentModel.DataAnnotations;

namespace GuarderiaMascotas.DTOs
{
    public class ClienteMascotaCreacionDTO
    {
        public int MascotaId { get; set; }
        //public DateTime FechaEntrada { get; set; }
        public string HoraEntrada { get; set; }
        //public DateTime FechaSalida { get; set; }
        public string HoraSalida { get; set; }
        [StringLength(300)]
        public string ContactoAdicional { get; set; }
    }
}
