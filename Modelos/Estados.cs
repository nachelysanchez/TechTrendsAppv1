using System.ComponentModel.DataAnnotations;

namespace TechTrendsAppv1.Modelos
{
    public class Estados
    {
        [Key]
        public int IdEstado { get; set; }
        public string Nombre { get; set; } = string.Empty;
    }
}
