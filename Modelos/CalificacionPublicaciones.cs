using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TechTrendsAppv1.Modelos
{
    public class CalificacionPublicaciones
    {
        [Key]
        public int IdCalificacion { get; set; }
        public int Valoracion { get; set; }
        public int IdPublicacion { get; set; }
        [ForeignKey("IdPublicacion")]
        public Publicaciones Publicacion { get; set; } = new();
    }
}
