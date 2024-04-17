using System.Linq.Expressions;
using TechTrendsAppv1.Modelos;

namespace TechTrendsAppv1.BLL.EstadosService
{
    public interface IEstadosService
    {
        public Task<List<Estados>> GetEstados();
        public Task<Estados> GetEstado(int id);
        public Task<List<Estados>> GetListAsync(Expression<Func<Estados, bool>> criterio);
    }
}
