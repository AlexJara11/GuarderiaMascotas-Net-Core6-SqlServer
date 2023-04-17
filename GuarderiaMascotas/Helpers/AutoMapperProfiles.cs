using AutoMapper;
using GuarderiaMascotas.DTOs;
using GuarderiaMascotas.Entidades;

namespace GuarderiaMascotas.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Mascota, MascotaDTO>().ReverseMap();
            CreateMap<MascotaCreacionDTO, Mascota>();

            CreateMap<Cliente, ClienteDTO>().ReverseMap();
            CreateMap<ClienteCreacionDTO, Cliente>()
                .ForMember(x => x.MascotasClientes, options => options.MapFrom(MapMascotasClientes));




            CreateMap<Cliente, ClienteDetallesDTO>()
                .ForMember(x => x.Mascos, options => options.MapFrom(MapClientesMascotas));

        }

        private List<MascotaClienteDetalleDTO> MapClientesMascotas(Cliente cliente, ClienteDetallesDTO clienteDetallesDTO)
        {
            var resultado = new List<MascotaClienteDetalleDTO>();
            if (cliente.MascotasClientes == null) { return resultado; }
            foreach (var mascotaCliente in cliente.MascotasClientes)
            {
                resultado.Add(new MascotaClienteDetalleDTO
                {
                    MascotaId = mascotaCliente.MascotaId,
                    HoraeEntrada = mascotaCliente.HoraEntrada,
                    HoraSalida = mascotaCliente.HoraSalida,
                    ContactoAdicional = mascotaCliente.ContactoAdicional
                });
                
            }
            return resultado;
        }
        private List<MascotasClientes> MapMascotasClientes(ClienteCreacionDTO clienteCreacionDTO, Cliente cliente)
        {
            var resultado = new List<MascotasClientes>();
            if (clienteCreacionDTO.Mascotas == null) { return resultado; }
            foreach (var mascota in clienteCreacionDTO.Mascotas)
            {
                resultado.Add(new MascotasClientes()
                {
                    MascotaId = mascota.MascotaId,
                    HoraEntrada = mascota.HoraEntrada,
                    HoraSalida = mascota.HoraSalida,
                    ContactoAdicional = mascota.ContactoAdicional
                });
            }
            return resultado;
        } 
    }
}
