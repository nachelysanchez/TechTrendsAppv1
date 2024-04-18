using System.Linq.Expressions;
using TechTrendsAppv1.Modelos;

namespace TechTrendsAppv1.BLL.PlantillasService
{
    public interface IPlantillasService
    {
        public bool Existe(int idplantilla);
        public Task<bool> Guardar(Plantillas plantilla);
        public Task<bool> Insertar(Plantillas plantilla);
        public Task<bool> Modificar(Plantillas plantilla);
        public Task<List<Plantillas>> GetPlantillas();
        public Task<List<Plantillas>> GetListAsync(Expression<Func<Plantillas, bool>> criterio);
    }
}
