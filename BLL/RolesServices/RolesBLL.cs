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
            return lista;
        }
        async Task<Modelos.Roles> IRolesService.GetRolAsync(int idRol)
        {
            Modelos.Roles rol = new();
            try
            {
                //TODO: Revisar porque explota y la tarea se cancela
                rol = await contexto.Roles.Where(x => x.IdRol == idRol)
                    .Include(x => x.Permisos)
                    .ThenInclude(x => x.Permiso)
                    .AsNoTracking()
                    .FirstOrDefaultAsync();
            }
            catch (Exception)
            {
                throw;
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
            return paso;
        }

        public async Task<List<Modelos.Roles>> GetPermisosRol(int idRol)
        {
            List<Modelos.Roles> permisos = new List<Modelos.Roles>();
            try
            {
                permisos = await contexto.Roles.Where(x => x.IdRol == idRol)
                    .Include(x => x.Permisos)
                    .ThenInclude(x => x.Permiso)
                    .ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return permisos;
        }

        public async Task<List<Permisos>> GetPermisos()
        {
            List<Permisos> permisos = new List<Permisos>();
            try
            {

                permisos =await contexto.Permisos.AsNoTracking().ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return permisos;
        }

        public async Task<List<PermisosRoles>> GetPermisosRoles()
        {
            List<PermisosRoles> permisosRoles = new List<PermisosRoles>();
            List<Permisos> permisos = new List<Permisos>();
            try
            {
                permisos = await GetPermisos();
                foreach (var item in permisos)
                {

                    permisosRoles.Add(new PermisosRoles
                    {
                        IdPermiso = item.IdPermiso,
                        Permiso = item,
                        Activo = false
                    });
                }
            }
            catch (Exception)
            {

                throw;
            }
            return permisosRoles;
        }
    }
}
