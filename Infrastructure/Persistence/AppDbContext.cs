using BackEndVirONet8.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackEndVirONet8.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<Persona> Personas => Set<Persona>();
        public DbSet<Deporte> Deportes => Set<Deporte>();
        public DbSet<PersonaDeporte> PersonaDeportes => Set<PersonaDeporte>();

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder b)
        {
            b.Entity<Deporte>()
                .HasIndex(d => d.Nombre)
                .IsUnique();

            b.Entity<Persona>(cfg =>
            {
                cfg.Property(p => p.Nombre).HasMaxLength(100).IsRequired();
                cfg.Property(p => p.PrimerApellido).HasMaxLength(100).IsRequired();
                cfg.Property(p => p.SegundoApellido).HasMaxLength(100);
                cfg.Property(p => p.FechaNacimiento).IsRequired();
                cfg.Property(p => p.Sexo).IsRequired();
            });

            b.Entity<PersonaDeporte>()
                .HasKey(pd => new { pd.PersonaId, pd.DeporteId });

            b.Entity<PersonaDeporte>()
                .HasOne(pd => pd.Persona)
                .WithMany(p => p.PersonaDeportes)
                .HasForeignKey(pd => pd.PersonaId);

            b.Entity<PersonaDeporte>()
                .HasOne(pd => pd.Deporte)
                .WithMany(d => d.PersonaDeportes)
                .HasForeignKey(pd => pd.DeporteId);

            b.Entity<Deporte>().HasData(
                new Deporte { Id = 1, Nombre = "Fútbol" },
                new Deporte { Id = 2, Nombre = "Básquetbol" },
                new Deporte { Id = 3, Nombre = "Tenis" },
                new Deporte { Id = 4, Nombre = "Natación" },
                new Deporte { Id = 5, Nombre = "Ciclismo" }
            );
        }
    }

}
