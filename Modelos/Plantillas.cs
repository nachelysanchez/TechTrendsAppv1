using System.ComponentModel.DataAnnotations;

namespace TechTrendsAppv1.Modelos
{
    public class Plantillas
    {
        [Key]
        public int IdPlantilla { get; set; }
        public DateTime Fecha { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string Contenido { get; set; } = string.Empty;
    }
}
