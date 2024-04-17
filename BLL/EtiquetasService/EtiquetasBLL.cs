using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using TechTrendsAppv1.DAL;
using TechTrendsAppv1.Modelos;

namespace TechTrendsAppv1.BLL.EtiquetasService
{
    public class EtiquetasBLL : IEtiquetasService
    {
        private readonly Contexto contexto;

        public EtiquetasBLL(Contexto _contexto)
        {
            this.contexto = _contexto;
        }

        public bool Existe(int idEtiqueta)
        {
            bool encontrado = false;
            try
            {
                encontrado = contexto.Etiquetas.Any(x => x.IdEtiqueta == idEtiqueta);
            }
            catch (Exception)
            {

                throw;
            }
            return encontrado;
        }

        public async Task<Etiquetas> GetEtiqueta(int id)
        {
            Etiquetas etiqueta = new Etiquetas();
            try
            {
                etiqueta = await contexto.Etiquetas
                    .Where(x => x.IdEtiqueta == id)
                    .AsNoTracking()
                    .FirstAsync();
            }
            catch (Exception)
            {

                throw;
            }
            return etiqueta;
        }

        public async Task<List<Etiquetas>> GetEtiquetas()
        {
            List<Etiquetas> etiqueta = new List<Etiquetas>();
            try
            {
                etiqueta = await contexto.Etiquetas
                    .AsNoTracking()
                    .ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
            return etiqueta;
        }

        public async Task<List<Etiquetas>> GetListAsync(Expression<Func<Etiquetas, bool>> criterio)
        {
            List<Etiquetas> lista = new List<Etiquetas>();
            try
            {
                lista = contexto.Etiquetas.Where(criterio).AsNoTracking().ToList();
            }
            catch (Exception)
            {

                throw;
            }
            return lista;
        }

        public async Task<bool> Guardar(Etiquetas etiqueta)
        {
            if (Existe(etiqueta.IdEtiqueta))
            {
                return await Modificar(etiqueta);
            }
            else
            {
                return await Insertar(etiqueta);
            }
        }

        public async Task<bool> Insertar(Etiquetas etiqueta)
        {
            bool paso = false;
            try
            {
                await contexto.Etiquetas.AddAsync(etiqueta);
                paso = await contexto.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            return paso;
        }

        public async Task<bool> Modificar(Etiquetas etiqueta)
        {
            bool paso = false;
            try
            {
                contexto.Etiquetas.Update(etiqueta);
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
