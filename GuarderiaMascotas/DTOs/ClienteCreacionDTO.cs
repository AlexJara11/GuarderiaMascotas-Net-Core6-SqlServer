using GuarderiaMascotas.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace GuarderiaMascotas.DTOs
{
    public class ClienteCreacionDTO
    {
        //public int Id { get; set; }
        [Required]
        [StringLength(300)]
        public string Nombre { get; set; }
        public int Edad { get; set; }
        [StringLength(10)]
        public string Identificacion { get; set; }
        [StringLength(30)]
        public string Direccion { get; set; }
        [StringLength(10)]
        public string Telefono { get; set; }


        [ModelBinder(BinderType = typeof(TypeBinder<List<ClienteMascotaCreacionDTO>>))]
        //public List<int> MascotasIDs { get; set; }
        public List<ClienteMascotaCreacionDTO> Mascotas { get; set; }
    }
}
