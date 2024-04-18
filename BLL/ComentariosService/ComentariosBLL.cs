using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using TechTrendsAppv1.DAL;
using TechTrendsAppv1.Modelos;

namespace TechTrendsAppv1.BLL.ComentariosService
{
    public class ComentariosBLL : IComentariosService
    {
        private readonly Contexto contexto;

        public ComentariosBLL(Contexto _contexto)
        {
            this.contexto = _contexto;
        }
        public async Task<List<Comentarios>> GetComentarios()
        {
            List<Comentarios> lista = new List<Comentarios>();

            try
            {
                lista = await contexto.Comentarios.AsNoTracking().ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
            return lista;
        }

        public async Task<List<Comentarios>> GetListAsync(Expression<Func<Comentarios, bool>> criterio)
        {
            List<Comentarios> lista = new List<Comentarios>();

            try
            {
                lista = await contexto.Comentarios.Where(criterio).AsNoTracking().ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
            return lista;
        }

        public async Task<bool> Insertar(Comentarios comentario)
        {
            bool paso = false;
            try
            {
                comentario.Publicacion = null;
                await contexto.Comentarios.AddAsync(comentario);
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
