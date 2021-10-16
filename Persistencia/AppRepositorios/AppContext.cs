using Microsoft.EntityFrameworkCore;
using Dominio;

namespace Persistencia
{
    public class AppContext:DbContext
    {
        //Atributos
        public DbSet<Arbitro> Arbitros {get;set;}
        public DbSet<Cancha> Canchas {get;set;}
        public DbSet<Deportista> Deportistas {get;set;}
        public DbSet<Entrenador> Entrenadores {get;set;}
        public DbSet<Equipo> Equipos {get;set;}
        public DbSet<Escenario> Escenarios {get;set;}
        public DbSet<EscuelaArbitro> EscuelaArbitros {get;set;}
        public DbSet<Municipio> Municipios {get;set;}
        public DbSet<Patrocinador> Patrocinadores {get;set;}
        public DbSet<Torneo> Torneos {get;set;}
        
        public DbSet<TorneoEquipo> TorneoEquipos {get;set;}
        
        //Metodos   -- optionsBuilder conexion con la base de datos
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured) // Si no esta configurada la base de datos
            {
                optionsBuilder.UseSqlServer("Data Source= (localdb)\\MSSQLLocalDB; Initial Catalog=EventosDepPioneros");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TorneoEquipo>().HasKey(x=> new{x.EquipoId,x.TorneoId}); // Se realiza debido a que hay un conflicto de dos ID en la entidad TorneoEquipo
        }
    }

}