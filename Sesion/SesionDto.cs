using TechTrendsAppv1.Modelos;
using TechTrendsAppv1.BLL.UsuariosServices;

namespace TechTrendsAppv1.Sesion
{
    public class SesionDto
    {
        public static int IdUsuarioLogueado { get; set; }
        private readonly UsuariosBLL usuariosService;

        public void SetUsuarioLog(int idUsuario)
        {
            IdUsuarioLogueado = idUsuario;
        }

        public int GetUsuarioLog()
        {
            return IdUsuarioLogueado;
        }
    }
}
