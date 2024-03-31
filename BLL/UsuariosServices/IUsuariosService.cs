using TechTrendsAppv1.Modelos;

namespace TechTrendsAppv1.BLL.UsuariosServices
{
    public interface IUsuariosService
    {
        public Task<Usuarios> Login(string email, string clave);
        public Task<Usuarios> GetUsuario(int idUsuario);
        public Task<Usuarios> GetUsuarioLogueado();
    }
}
