using Microsoft.EntityFrameworkCore;
using TechTrendsAppv1.DAL;
using TechTrendsAppv1.Modelos;
using TechTrendsAppv1.Sesion;

namespace TechTrendsAppv1.BLL.UsuariosServices
{
    public class UsuariosBLL : IUsuariosService
    {
        private readonly Contexto contexto;
        private readonly SesionDto sesion;

        public UsuariosBLL(Contexto _contexto, SesionDto dto)
        {
            this.contexto = _contexto;
            this.sesion = dto;
        }

        public async Task<Usuarios> GetUsuario(int idUsuario)
        {
            return await contexto.Usuarios.FindAsync(idUsuario);
        }

        async Task<Usuarios> IUsuariosService.Login(string email, string clave)
        {
            try
            {
                var user = contexto.Usuarios.Where(x => x.Email == email && x.Contrasena == clave).FirstOrDefault();
                if (user != null)
                {
                    sesion.SetUsuarioLog(user.IdUsuario);
                }
                return user;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<Usuarios> GetUsuarioLogueado()
        {
            int usuarioL = sesion.GetUsuarioLog();
            try
            {
                if (usuarioL != 0)
                {
                   return GetUsuario(usuarioL);
                }
                else
                {
                    return GetUsuario(0);
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
