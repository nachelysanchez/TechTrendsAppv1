using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Threading;
using TechTrendsAppv1.BLL.RolesServices;
using TechTrendsAppv1.DAL;
using TechTrendsAppv1.Modelos;

namespace TechTrendsAppv1.BLL.Roles
{
    public class RolesBLL : IRolesService
    {
        private readonly Contexto contexto;

        public RolesBLL(Contexto _contexto)
        {
            this.contexto = _contexto;
        }

        public bool Existe(int id)
        {
            bool encontrado = false;
            try
            {
                encontrado = contexto.Roles.Any(t => t.IdRol == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return encontrado;
        }

        /// <summary>
        /// Permite buscar una tarea mediante id
        /// </summary>
        /// <param name="id">El Id de la entidad que se desea buscar</param>
        async Task<List<Modelos.Roles>> IRolesService.GetRolesAsync()
        {
            try
            {
                var roles = await contexto.Roles.ToListAsync();
                return roles;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        async Task<List<Modelos.Roles>> IRolesService.GetListAsync(Expression<Func<Modelos.Roles, bool>> criterio)
        {
            List<Modelos.Roles> lista = new List<Modelos.Roles>();

            try
            {
                lista = contexto.Roles.Where(criterio).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }
        async Task<Modelos.Roles> IRolesService.GetRolAsync(int idRol)
        {
            Modelos.Roles rol = new();
            try
            {
                rol = await contexto.Roles.FindAsync(idRol);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return rol;
        }
        async Task<bool> IRolesService.Guardar(Modelos.Roles rol)
        {
            if (!Existe(rol.IdRol))
            {
                return await Insertar(rol);
            }
            else
            {
                return await Modificar(rol);
            }
        }
        private async Task<bool> Insertar(Modelos.Roles rol)
        {
            bool paso = false;
            try
            {
                await contexto.Roles.AddAsync(rol);
                foreach (var item in rol.Permisos)
                {
                    contexto.Entry(item).State = EntityState.Added;
                }
                paso = await contexto.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }
        private async Task<bool> Modificar(Modelos.Roles rol)
        {
            bool paso = false;
            try
            {
                var rolAnterior = await contexto.Roles.Where(x => x.IdRol == rol.IdRol)
                    .Include(x => x.Permisos)
                    .AsNoTracking()
                    .SingleOrDefaultAsync();

                await contexto.Database.ExecuteSqlAsync($"DELETE FROM PermisosRoles WHERE IdRol = {rol.IdRol}");

                foreach (var item in rol.Permisos)
                {
                    contexto.Entry(item).State = EntityState.Added;
                }

                contexto.Entry(rol).State = EntityState.Modified;
                paso = await contexto.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }
        async Task<bool> IRolesService.Eliminar(int id)
        {
            bool paso = false;
            try
            {
                var rol = await contexto.Roles.FindAsync(id);
                if (rol != null)
                {
                    contexto.Roles.Remove(rol);
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();

            }
            return paso;
        }

        public async Task<List<PermisosRoles>> GetPermisosRol(int idRol)
        {
            List<PermisosRoles> permisos = new List<PermisosRoles>();
            try
            {
                //permisos = await contexto.PermisosRoles.Where(x => x.IdRol == idRol).ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return permisos;
        }
    }
}
