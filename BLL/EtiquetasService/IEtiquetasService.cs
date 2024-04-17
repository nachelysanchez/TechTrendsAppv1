using System.Linq.Expressions;
using TechTrendsAppv1.Modelos;

namespace TechTrendsAppv1.BLL.EtiquetasService
{
    public interface IEtiquetasService
    {
        public bool Existe(int idEtiqueta);
        public Task<bool> Guardar(Etiquetas etiqueta);
        public Task<bool> Insertar(Etiquetas etiqueta);
        public Task<bool> Modificar(Etiquetas etiqueta);
        public Task<List<Etiquetas>> GetEtiquetas();
        public Task<Etiquetas> GetEtiqueta(int id);
        public Task<List<Etiquetas>> GetListAsync(Expression<Func<Etiquetas, bool>> criterio);
    }
}
