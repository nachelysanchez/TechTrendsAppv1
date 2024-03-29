using System.ComponentModel.DataAnnotations;

namespace TechTrendsAppv1.Modelos
{
    public class Roles
    {
        [Key]
        public int IdRol { get; set; }
        public string Nombre { get; set; } = string.Empty;
    }
}
