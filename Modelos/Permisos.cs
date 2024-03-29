using System.ComponentModel.DataAnnotations;

namespace TechTrendsAppv1.Modelos
{
    public class Permisos
    {
        [Key]
        public int IdPermiso { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
    }
}
