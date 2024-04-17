using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using TechTrendsAppv1.DAL;
using TechTrendsAppv1.Modelos;

namespace TechTrendsAppv1.BLL.EstadosService
{
    public class EstadosBLL : IEstadosService
    {
        private readonly Contexto contexto;

        public EstadosBLL(Contexto _contexto)
        {
            this.contexto = _contexto;
        }

        public async Task<Estados> GetEstado(int id)
        {
            Estados estados = new Estados();
            try
            {
                estados = await contexto.Estados.Where(x => x.IdEstado == id)
                    .AsNoTracking()
                    .FirstAsync();
            }
            catch (Exception)
            {

                throw;
            }
            return estados;
        }

        public async Task<List<Estados>> GetEstados()
        {
            List<Estados> lista = new List<Estados>();

            try
            {
                lista = await contexto.Estados.AsNoTracking().ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
            return lista;
        }

        public async Task<List<Estados>> GetListAsync(Expression<Func<Estados, bool>> criterio)
        {
            List<Estados> lista = new List<Estados>();

            try
            {
                lista = contexto.Estados.Where(criterio).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            return lista;
        }
    }
}
