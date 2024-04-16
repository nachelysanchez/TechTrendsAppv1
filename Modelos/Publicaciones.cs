using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TechTrendsAppv1.Modelos
{
    public class Publicaciones
    {
        [Key]
        public int IdPublicacion { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public string Titulo { get; set; } = string.Empty;
        public string Autor { get; set; } = string.Empty;
        public string Contenido { get; set; } = string.Empty;
        public byte[]? Audiovisual { get; set; }
        public bool Visibilidad { get; set; }
        public int IdEstado { get; set; }
        [ForeignKey("IdEstado")]
        public Estados Estado { get; set; }
        public int IdEtiqueta { get; set; }
        [ForeignKey("IdEtiqueta")]
        public Etiquetas Etiqueta { get; set; }
    }
}


public class Carta
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string imgUrl { get; set; }
}