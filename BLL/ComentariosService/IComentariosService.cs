using System.Linq.Expressions;
using TechTrendsAppv1.Modelos;

namespace TechTrendsAppv1.BLL.ComentariosService
{
    public interface IComentariosService
    {
        public Task<bool> Insertar(Comentarios comentario);
        public Task<List<Comentarios>> GetComentarios();
        public Task<List<Comentarios>> GetListAsync(Expression<Func<Comentarios, bool>> criterio);
    }
}
