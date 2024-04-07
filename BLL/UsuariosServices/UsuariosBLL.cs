using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
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

        public void CerrarSesion()
        {
            sesion.SetUsuarioLog(0);
        }

        public async Task<List<Usuarios>> GetUsuarios()
        {
            List<Usuarios> usuarios = new List<Usuarios>();
            try
            {
                usuarios = await contexto.Usuarios.Include(x => x.rol).AsNoTracking().ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
            return usuarios;
        }

        public async Task<List<Usuarios>> GetListAsync(Expression<Func<Usuarios, bool>> criterio)
        {
            List<Usuarios> lista = new List<Usuarios>();

            try
            {
                lista = await contexto.Usuarios.Where(criterio).Include(x => x.rol).ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
            return lista;
        }
    }
}
