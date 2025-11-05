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

                // Relación Equipo - Líder (Usuario)
                entity.HasOne(e => e.Lider)
                      .WithMany()
                      .HasForeignKey(e => e.LiderId)
                      .OnDelete(DeleteBehavior.Restrict); // No borra equipo si se borra usuario

                // Relación Equipo - Usuarios (N:M) para los miembros del equipo
                entity.HasMany(e => e.Usuarios)
                      .WithMany(u => u.Equipos)
                      .UsingEntity<Dictionary<string, object>>(
                        "EquipoUsuarios",
                        j => j
                            .HasOne<Usuario>()
                            .WithMany()
                            .HasForeignKey("UsuarioId")
                            .OnDelete(DeleteBehavior.NoAction),
                        j => j
                            .HasOne<Equipo>()
                            .WithMany()
                            .HasForeignKey("EquipoId")
                            .OnDelete(DeleteBehavior.NoAction),
                        j =>
                        {
                            j.HasKey("EquipoId", "UsuarioId");
                            j.ToTable("EquipoUsuarios");
                        });
            });

            // DATOS INICIALES

            // Usuarios iniciales
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    Id = 1,
                    Nombre = "Emilio",
                    Apellido = "Certo",
                    Email = "emicerto@utn.com",
                    Clave = "emicerto123",
                    Pais = "Argentina",
                    NombreUsuario = "emiliokmkz",
                    FechaAlta = DateTime.Now,
                    Admin = true
                },
                new Usuario
                {
                    Id = 2,
                    Nombre = "Gian Marco",
                    Apellido = "Mercanzini",
                    Email = "gianimercan@utn.com",
                    Clave = "gianmarco123",
                    Pais = "Argentina",
                    NombreUsuario = "gianmarco",
                    FechaAlta = DateTime.Now,
                    Admin = true
                },
                new Usuario
                {
                    Id = 3,
                    Nombre = "Augusto",
                    Apellido = "Lescano",
                    Email = "augusles@utn.com",
                    Clave = "augusto123",
                    Pais = "Argentina",
                    NombreUsuario = "augus",
                    FechaAlta = DateTime.Now,
                    Admin = true
                },
                new Usuario
                {
                    Id = 4,
                    Nombre = "Naruto",
                    Apellido = "Uzumaki",
                    Email = "naruzumaki@konoha.com",
                    Clave = "naruto123",
                    Pais = "Argentina",
                    NombreUsuario = "uzumakinaruto",
                    FechaAlta = DateTime.Now,
                    Admin = false
                },
                new Usuario
                {
                    Id = 5,
                    Nombre = "Sasuke",
                    Apellido = "Uchiha",
                    Email = "sasukeuchiha@uchihas.com",
                    Clave = "sasuke123",
                    Pais = "Argentina",
                    NombreUsuario = "uchihasasuke",
                    FechaAlta = DateTime.Now,
                    Admin = false
                }
            );

            // Juegos iniciales
            modelBuilder.Entity<Juego>().HasData(
                new Juego
                {
                    Id = 1,
                    Nombre = "League of Legends",
                    Descripcion = "Juego de estrategia por equipos 5v5"
                },
                new Juego
                {
                    Id = 2,
                    Nombre = "Counter-Strike 2",
                    Descripcion = "Shooter táctico por equipos 5v5"
                },
                new Juego
                {
                    Id = 3,
                    Nombre = "Valorant",
                    Descripcion = "Shooter táctico con habilidades especiales"
                },
                new Juego
                {
                    Id = 4,
                    Nombre = "Fortnite",
                    Descripcion = "Battle Royale con construcción"
                },
                new Juego
                {
                    Id = 5,
                    Nombre = "EA FC 26",
                    Descripcion = "Simulador de fútbol con licencias oficiales y gameplay realista"
                },
                new Juego
                {
                    Id = 6,
                    Nombre = "Street Fighter VI",
                    Descripcion = "Legendario juego de lucha con combates intensos 1v1"
                },
                new Juego
                {
                    Id = 7,
                    Nombre = "Clash royale",
                    Descripcion = "Estrategia en tiempo real con cartas coleccionables y batallas rápidas"
                }
            );

            // Tipos de Torneo iniciales
            modelBuilder.Entity<TipoTorneo>().HasData(
                new TipoTorneo
                {
                    Id = 1,
                    Nombre = "1v1",
                    Descripcion = "Torneo individual donde cada jugador compite por su cuenta"
                },
                new TipoTorneo
                {
                    Id = 2,
                    Nombre = "2v2",
                    Descripcion = "Torneo por equipos de 2 jugadores"
                },
                new TipoTorneo
                {
                    Id = 3,
                    Nombre = "5v5",
                    Descripcion = "Torneo por equipos de 5 jugadores"
                },
                new TipoTorneo
                {
                    Id = 4,
                    Nombre = "Battle Royale Individual",
                    Descripcion = "Torneo Battle Royale individual"
                },
                new TipoTorneo
                {
                    Id = 5,
                    Nombre = "Battle Royale Grupal",
                    Descripcion = "Torneo Battle Royale por equipos de hasta 4 jugadores"
                }
            );

            // Equipos iniciales
            modelBuilder.Entity<Equipo>().HasData(
                new Equipo
                {
                    Id = 1,
                    Nombre = "Solids Snakes",
                    LiderId = 2
                },
                new Equipo
                {
                    Id = 2,
                    Nombre = "Los dragones",
                    LiderId = 1
                }
            );
        }
    }
}
