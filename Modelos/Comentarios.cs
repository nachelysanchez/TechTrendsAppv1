using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TechTrendsAppv1.Modelos
{
    public class Comentarios
    {
        [Key]
        public int IdComentario { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public string Contenido { get; set; } = string.Empty;
        public string Autor { get; set; } = string.Empty;
        public int IdPublicacion { get; set; }
        [ForeignKey("IdPublicacion")]
        public Publicaciones Publicacion { get; set; } = new();
    }
}
