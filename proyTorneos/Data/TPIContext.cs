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
        public DbSet<Juego> Juegos { get; set; }
        public DbSet<Inscripcion> Inscripciones { get; set; }
        public DbSet<Equipo> Equipos { get; set; }

        internal TPIContext()
        {
            //ante cambios en la estructura de la base de datos
            //descomentar la linea de codigo "this.Database.EnsureDeleted();"
            //luego correr el programa
            //y en la proxima ejecucion volver a comentar la linea "this.Database.EnsureDeleted();"
            //this.Database.EnsureDeleted();
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

                entity.Property(e => e.Clave)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.Pais)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.NombreUsuario)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.FechaAlta)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Admin)
                     .IsRequired();

                // Restricción únicas
                entity.HasIndex(e => e.Email)
                    .IsUnique();

                entity.HasIndex(e => e.NombreUsuario)
                    .IsUnique();
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


            modelBuilder.Entity<Juego>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Torneo>(entity =>
            {
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

                entity.Property(e => e.FechaFin)
                    .IsRequired();

                entity.Property(e => e.FechaInicioDeInscripciones)
                    .IsRequired();

                entity.Property(e => e.FechaFinDeInscripciones)
                    .IsRequired();

                entity.Property(e => e.Resultado)
                    .IsRequired();

                entity.Property(e => e.Region)
                    .IsRequired();

                entity.Property(e=>e.Estado)
                    .IsRequired();
                
                entity.HasOne(t => t.Inscripcion)
                    .WithOne(i => i.Torneo)
                    .HasForeignKey<Inscripcion>(i => i.TorneoId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(u => u.TipoDeTorneo)
                      .WithMany(i => i.Torneos)
                      .HasForeignKey(u => u.TipoDeTorneoId)
                      .IsRequired(false)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(u => u.Juego)
                      .WithMany(i => i.Torneos)
                      .HasForeignKey(u => u.JuegoId)
                      .IsRequired(false)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            /*modelBuilder.Entity<Inscripcion>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                .ValueGeneratedOnAdd();

                entity.Property(e => e.Estado)
                    .IsRequired();

                entity.Property(e => e.FechaApertura)
                    .IsRequired();

                entity.Property(e => e.FechaCierre)
                    .IsRequired();

                //Relación Inscripción - Usuario (N:M)
                 entity.HasMany(i => i.Usuarios)
                     .WithMany(u => u.Inscripciones)
                     .UsingEntity(j => j.ToTable("UsuariosInscripciones"));

                //Relación Inscripción - Equipo (N:M)
                entity.HasMany(i => i.Equipos)
                    .WithMany(e => e.Inscripciones)
                    .UsingEntity(j => j.ToTable("EquiposInscripciones"));
            });*/



            modelBuilder.Entity<Inscripcion>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                .ValueGeneratedOnAdd();

                entity.Property(e => e.Estado)
                    .IsRequired();

                entity.Property(e => e.FechaApertura)
                    .IsRequired();

                entity.Property(e => e.FechaCierre)
                    .IsRequired();

                //Relación Inscripción - Usuario (N:M) CON CLAVE PRIMARIA DEFINIDA
                entity.HasMany(i => i.Usuarios)
                    .WithMany(u => u.Inscripciones)
                    .UsingEntity<Dictionary<string, object>>(
                        "UsuariosInscripciones",
                        j => j
                            .HasOne<Usuario>()
                            .WithMany()
                            .HasForeignKey("UsuarioId")
                            .OnDelete(DeleteBehavior.NoAction),
                        j => j
                            .HasOne<Inscripcion>()
                            .WithMany()
                            .HasForeignKey("InscripcionId")
                            .OnDelete(DeleteBehavior.NoAction),
                        j =>
                        {
                            j.HasKey("UsuarioId", "InscripcionId");
                            j.ToTable("UsuariosInscripciones");
                        });

                //Relación Inscripción - Equipo (N:M) CON CLAVE PRIMARIA DEFINIDA
                entity.HasMany(i => i.Equipos)
                    .WithMany(e => e.Inscripciones)
                    .UsingEntity<Dictionary<string, object>>(
                        "EquiposInscripciones",
                        j => j
                            .HasOne<Equipo>()
                            .WithMany()
                            .HasForeignKey("EquipoId")
                            .OnDelete(DeleteBehavior.NoAction),
                        j => j
                            .HasOne<Inscripcion>()
                            .WithMany()
                            .HasForeignKey("InscripcionId")
                            .OnDelete(DeleteBehavior.NoAction),
                        j =>
                        {
                            j.HasKey("EquipoId", "InscripcionId");
                            j.ToTable("EquiposInscripciones");
                        });
            });



            modelBuilder.Entity<Equipo>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                .ValueGeneratedOnAdd();

                entity.Property(e => e.Nombre)
                    .IsRequired();

                entity.HasOne(e => e.Lider)
                    .WithMany()
                    .HasForeignKey(e => e.LiderId)
                    .OnDelete(DeleteBehavior.Restrict); //Esto evita que si se elimina un usuario, se borre accidentalmente su equipo.
            });
        }
    }
}
