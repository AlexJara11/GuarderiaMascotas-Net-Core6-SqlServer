namespace GuarderiaMascotas.DTOs
{
    public class ClienteDetallesDTO: ClienteDTO
    {
        public List<MascotaClienteDetalleDTO> Mascos { get; set; }
    }
}
