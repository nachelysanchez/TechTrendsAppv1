using Microsoft.EntityFrameworkCore;
using TechTrendsAppv1.Modelos;

namespace TechTrendsAppv1.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Publicaciones> Publicaciones { get; set; }
        public DbSet<Comentarios> Comentarios { get; set; }
        public DbSet<CalificacionPublicaciones> CalificacionPublicaciones { get; set; }
        public DbSet<Permisos> Permisos { get; set; }
        public DbSet<Etiquetas> Etiquetas { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<RespuestaComentarios> RespuestaComentarios { get; set; }
        public DbSet<Estados> Estados { get; set; }
        public DbSet<Plantillas> Plantillas { get; set; }

        public Contexto(DbContextOptions<Contexto> options) : base(options) { }
    }
}
