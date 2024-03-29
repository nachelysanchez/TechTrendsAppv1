using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TechTrendsAppv1.Modelos
{
    public class PermisosRoles
    {
        [Key]
        public int IdPermisoRol { get; set; }
        public int IdRol { get; set; }
        [ForeignKey("IdRol")]
        public Roles Rol { get; set; } = new();

        public int IdPermiso { get; set; }
        [ForeignKey("IdPermiso")]
        public Permisos Permiso { get; set; } = new();
    }
}
