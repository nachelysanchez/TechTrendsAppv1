using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TechTrendsAppv1.Modelos
{
    public class Etiquetas
    {
        [Key]
        public int IdEtiqueta { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public int Color { get; set; }
    }
}
