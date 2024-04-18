using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using TechTrendsAppv1.DAL;
using TechTrendsAppv1.Modelos;

namespace TechTrendsAppv1.BLL.CalificacionService
{
    public class CalificacionesBLL : ICalificacionesService
    {
        private readonly Contexto contexto;

        public CalificacionesBLL(Contexto _contexto)
        {
            this.contexto = _contexto;
        }

        public async Task<decimal> Calculo(int IdPublicacion)
        {
            List<CalificacionPublicacion> lista = new();
            decimal valor = 0;
            try
            {
                lista = await contexto.CalificacionPublicacion.Where(x => x.IdPublicacion == IdPublicacion).AsNoTracking().ToListAsync();
                if(lista.Count > 0)
                {

                    foreach (var item in lista)
                    {

                        valor += item.Valoracion;
                    }
                    valor /= lista.Count;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return valor;
        }

        public async Task<List<CalificacionPublicacion>> GetListAsync(Expression<Func<CalificacionPublicacion, bool>> criterio)
        {
            List<CalificacionPublicacion> lista = new List<CalificacionPublicacion>();

            try
            {
                lista = await contexto.CalificacionPublicacion.Where(criterio).AsNoTracking().ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
            return lista;
        }

        public async Task<bool> Insertar(CalificacionPublicacion calificacion)
        {
            bool paso = false;
            try
            {
                calificacion.Publicacion = null;
                await contexto.CalificacionPublicacion.AddAsync(calificacion);
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
