using AutoMapper;
using GuarderiaMascotas.DTOs;
using GuarderiaMascotas.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GuarderiaMascotas.Controllers
{
    [ApiController]
    [Route("api/clientes")]
    public class ClientesController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ClientesController(ApplicationDbContext context,
            IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<List<ClienteDTO>>> Get()
        {
            var clientes = await context.Clientes.ToListAsync();
            var dtos = mapper.Map<List<ClienteDTO>>(clientes);
        
            return dtos;
        }
        //[HttpGet("{id:int}", Name = "obtenerCliente")]
        //public async Task<ActionResult<ClienteDTO>> Get(int id)
        //{
        //    var cliente = await context.Clientes
        //        //.Include(x => x.MascotasClientes).ThenInclude(x => x.Mascota)
        //        .FirstOrDefaultAsync(x => x.Id == id);
        //    if (cliente == null)
        //    {
        //        return NotFound();
        //    }
        //    var dto = mapper.Map<ClienteDTO>(cliente);
        //    return dto;

        //}


        [HttpGet("{id:int}", Name = "obtenerCliente")]
        public async Task<ActionResult<ClienteDetallesDTO>> Get(int id)
        {
            var cliente = await context.Clientes
                .Include(x => x.MascotasClientes).ThenInclude(x => x.Mascota)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }
            var dto = mapper.Map<ClienteDetallesDTO>(cliente);
            return dto;

        }



        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ClienteCreacionDTO clienteCreacionDTO)
        {
            var cliente = mapper.Map<Cliente>(clienteCreacionDTO);
            context.Add(cliente);
            await context.SaveChangesAsync();
            var clienteDTO = mapper.Map<ClienteDTO>(cliente);

            return new CreatedAtRouteResult("obtenerCliente", new { id = clienteDTO.Id }, clienteDTO);
        }
        //[HttpPut("{id}")]
        //public async Task<ActionResult> Put(int id, [FromBody] ClienteCreacionDTO clienteCreacionDTO)
        //{
        //    var cliente = await context.Clientes
        //        .Include(x => x.MascotasClientes)
        //        .FirstOrDefaultAsync(x => x.Id == id);
        //    if (cliente == null) { return NotFound(); }
        //    cliente = mapper.Map(clienteCreacionDTO, cliente);
        //    cliente = mapper.Map<Cliente>(clienteCreacionDTO);
        //    cliente.Id = id;
        //    context.Entry(cliente).State = EntityState.Modified;
        //    await context.SaveChangesAsync();
        //    return NoContent();
        //}
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ClienteCreacionDTO clienteCreacionDTO)
        {
            var cliente = await context.Clientes
               .Include(x => x.MascotasClientes)
               .FirstOrDefaultAsync(x => x.Id == id);
            if (cliente == null) { return NotFound(); }

            cliente = mapper.Map(clienteCreacionDTO, cliente);

            await context.SaveChangesAsync();
            return NoContent();
           

        }



        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Clientes.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound();
            }
            context.Remove(new Cliente() { Id = id });
            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}
