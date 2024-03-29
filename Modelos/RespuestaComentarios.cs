using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TechTrendsAppv1.Modelos
{
    public class RespuestaComentarios
    {
        [Key]
        public int IdResComentario { get; set; }
        public DateTime Fecha { get; set; }
        public string Contenido { get; set; } = string.Empty;
        public string Autor { get; set; } = string.Empty;
        public int IdComentario { get; set; }
        [ForeignKey("IdComentario")]
        public Comentarios Comentario { get; set; } = new();
    }
}
