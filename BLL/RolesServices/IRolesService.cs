using System.Linq.Expressions;
using System.Threading;
using TechTrendsAppv1.Modelos;

namespace TechTrendsAppv1.BLL.RolesServices
{
    public interface IRolesService
    {
        public Task<List<Modelos.Roles>> GetRolesAsync();
        public Task<List<Modelos.Roles>> GetListAsync(Expression<Func<Modelos.Roles, bool>> criterio);
        public Task<Modelos.Roles> GetRolAsync(int idRol);
        public Task<bool> Guardar(Modelos.Roles rol);
        public Task<bool> Eliminar(int id);

    }
}
