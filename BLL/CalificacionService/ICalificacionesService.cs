using System.Linq.Expressions;
using TechTrendsAppv1.Modelos;

namespace TechTrendsAppv1.BLL.CalificacionService
{
    public interface ICalificacionesService
    {
        public Task<bool> Insertar(CalificacionPublicacion calificacion);
        public Task<decimal> Calculo(int IdPublicacion);
        public Task<List<CalificacionPublicacion>> GetListAsync(Expression<Func<CalificacionPublicacion, bool>> criterio);
    }
}
