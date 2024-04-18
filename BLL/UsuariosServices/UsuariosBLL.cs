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
                usuarios = await contexto.Usuarios.Include(x => x.Rol).AsNoTracking().ToListAsync();
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
                lista = await contexto.Usuarios.Where(criterio)
                    .Include(x => x.Rol)
                    .AsNoTracking()
                    .ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
            return lista;
        }

        public async Task<bool> ModificarUsuario(Usuarios usuario)
        {
            bool paso = false;
            Usuarios userAux = usuario;
            try
            {
                userAux.Rol = null;
                contexto.Usuarios.Update(usuario);
                paso = await contexto.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public async Task<bool> RegistrarUsuario(Usuarios usuario)
        {
            bool paso = false;
            try
            {
                usuario.IdRol = 4;
                await contexto.Usuarios.AddAsync(usuario);
                paso = await contexto.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            return paso;
        }
    }
}
