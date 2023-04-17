using System.ComponentModel.DataAnnotations;

namespace GuarderiaMascotas.Entidades
{
    public class ClientesMascotas
    {
        public int MascotaId { get; set; }
        public int ClienteId { get; set; }
        //public DateTime FechaEntrada { get; set; }
        public string HoraEntrada { get; set; }
       // public DateTime FechaSalida { get; set; }
        public string HoraSalida { get; set; }
        [StringLength(300)]
        public string ContactoAdicional { get; set; }

        public Cliente Cliente { get; set; }
        public Mascota Mascota { get; set; }

    }
}
