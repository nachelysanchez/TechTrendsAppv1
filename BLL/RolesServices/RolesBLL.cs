using Microsoft.EntityFrameworkCore;
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

        /// <summary>
        /// Permite buscar una tarea mediante id
        /// </summary>
        /// <param name="id">El Id de la entidad que se desea buscar</param>
        public async Task<List<Modelos.Roles>> GetRolesAsync()
        {
            var roles = await contexto.Roles.ToListAsync();
            return roles;
        }
    }
}
