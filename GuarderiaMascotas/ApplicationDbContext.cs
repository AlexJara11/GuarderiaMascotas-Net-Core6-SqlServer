using GuarderiaMascotas.Entidades;
using Microsoft.EntityFrameworkCore;
namespace GuarderiaMascotas
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MascotasClientes>()
                .HasKey(x => new { x.MascotaId, x.ClienteId });
            base.OnModelCreating(modelBuilder);
        }


        public DbSet<Mascota> Mascota { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        //public DbSet<ClienteMascotas> ClienteMascota { get; set; }
        //public DbSet<ClientesMascotas> ClientesMascotas { get; set; }
        public DbSet<MascotasClientes> MascotasClientes { get; set; }
    }
}
