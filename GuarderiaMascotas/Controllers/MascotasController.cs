using AutoMapper;
using GuarderiaMascotas.DTOs;
using GuarderiaMascotas.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GuarderiaMascotas.Controllers
{
    [ApiController]
    [Route("api/mascotas")]
    public class MascotasController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public MascotasController(ApplicationDbContext context,
            IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<MascotaDTO>>> Get()
        {
            var entidades = await context.Mascota.ToListAsync();
            var dtos = mapper.Map<List<MascotaDTO>>(entidades);
            return dtos;
        }
        [HttpGet("{id:int}", Name ="obtenerMascota")]
        public async Task<ActionResult<MascotaDTO>> Get(int id)
        {
            var entidad = await context.Mascota.FirstOrDefaultAsync(x => x.Id == id);
            if (entidad == null)
            {
                return NotFound();
            }
            var dto = mapper.Map<MascotaDTO>(entidad);
            return dto;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] MascotaCreacionDTO mascotaCreacionDTO)
        {
            var entidad = mapper.Map<Mascota>(mascotaCreacionDTO);
            context.Add(entidad);
            await context.SaveChangesAsync();

            var mascotaDTO = mapper.Map<MascotaDTO>(entidad);

            return new CreatedAtRouteResult("obtenerMascota", new { id = mascotaDTO.Id }, mascotaDTO);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] MascotaCreacionDTO mascotaCreacionDTO)
        {
            var entidad = mapper.Map<Mascota>(mascotaCreacionDTO);
            entidad.Id = id;
            context.Entry(entidad).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Mascota.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound();
            }
            context.Remove(new  Mascota() { Id = id });
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
