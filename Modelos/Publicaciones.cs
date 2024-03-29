using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TechTrendsAppv1.Modelos
{
    public class Publicaciones
    {
        [Key]
        public int IdPublicacion { get; set; }
        public DateTime Fecha { get; set; }
        public string Autor { get; set; } = string.Empty;
        public string Contenido { get; set; } = string.Empty;
        public byte[]? Audiovisual { get; set; }
        public int Visibilidad { get; set; }
        public int IdEstado { get; set; }
        [ForeignKey("IdEstado")]
        public Estados Estado { get; set; } = new();
        public int IdEtiqueta { get; set; }
        [ForeignKey("IdEtiquera")]
        public Etiquetas Etiqueta { get; set; } = new();
    }
}
