using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TechTrendsAppv1.Modelos
{
    public class CalificacionPublicacion
    {
        [Key]
        public int IdCalificacionPublicacion { get; set; }
        public int Valoracion { get; set; }
        public int IdPublicacion { get; set; }
        [ForeignKey("IdPublicacion")]
        public Publicaciones Publicacion { get; set; } = new();
    }
}
