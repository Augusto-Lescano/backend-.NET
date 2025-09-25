using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace Data
{
    public class TPIContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Torneo> Torneos { get; set; }
        public DbSet<TipoTorneo> TipoTorneos { get; set; }

        internal TPIContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .Build();

                string connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ClaveHash)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Salt)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Pais)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.NombreUsuario)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.Rol)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.FechaAlta)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasMaxLength(2);

                // Restricción únicas
                entity.HasIndex(e => e.Email)
                    .IsUnique();

                entity.HasIndex(e => e.NombreUsuario)
                    .IsUnique();

                // Usuario administrador inicial
                var adminUser = new Usuario(1, "admin", "admin", "admin@tpi.com", "admin123", "Argentina", "admin", "Admin", DateTime.Now, true);
                entity.HasData(new
                {
                    Id = adminUser.Id,
                    Nombre = adminUser.Nombre,
                    Apellido = adminUser.Apellido,
                    Email = adminUser.Email,
                    ClaveHash = adminUser.ClaveHash, // Se va a generar automáticamente
                    Salt = adminUser.Salt,           // Se va a generar automáticamente
                    Pais = adminUser.Pais,
                    NombreUsuario = adminUser.NombreUsuario,
                    Rol = adminUser.Rol,
                    FechaAlta = adminUser.FechaAlta,
                    Activo = adminUser.Activo
                });
            });

            modelBuilder.Entity<TipoTorneo>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(800);
            });

            modelBuilder.Entity<Torneo>(entity => {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id) 
                    .ValueGeneratedOnAdd();
                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(e => e.DescripcionDeReglas)
                    .IsRequired()
                    .HasMaxLength(255);
                entity.Property(e => e.CantidadDeJugadores)
                    .IsRequired();
                entity.Property(e => e.FechaInicio)
                    .IsRequired();
                entity.Property(e=>e.FechaFin)
                    .IsRequired();
                entity.Property(e=>e.FechaInicioDeInscripciones)
                    .IsRequired();
                entity.Property(e=>e.FechaFinDeInscripciones)
                    .IsRequired();
                entity.Property(e => e.Resultado)
                    .IsRequired();
                entity.Property(e=>e.Region)
                    .IsRequired();
                entity.Property(e=>e.Estado)
                    .IsRequired();
                
            });
        }
    }
}
