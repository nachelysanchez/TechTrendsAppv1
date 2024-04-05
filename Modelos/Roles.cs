using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechTrendsAppv1.Modelos
{
    public class Roles
    {
        [Key]
        public int IdRol { get; set; }
        public string Nombre { get; set; } = string.Empty;

        [ForeignKey("IdRol")]
        public List<PermisosRoles> Permisos { get; set; } = new List<PermisosRoles>();
    }
}
