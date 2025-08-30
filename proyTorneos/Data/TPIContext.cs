using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Domain.Model;
using Microsoft.Extensions.Configuration;


namespace Data
{
    public class TPIContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }

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
                    .HasMaxLength(100);

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255);

                // Restricción única para Email
                entity.HasIndex(e => e.Email)
                    .IsUnique();

                entity.Property(e => e.Pais)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.GamerTag)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.Rol)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.FechaAlta)
                    .IsRequired()
                    .HasMaxLength(50);
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
        }
    }
}
