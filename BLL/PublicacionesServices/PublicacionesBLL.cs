using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using TechTrendsAppv1.DAL;
using TechTrendsAppv1.Modelos;

namespace TechTrendsAppv1.BLL.PublicacionesServices
{
    public class PublicacionesBLL : IPublicacionesService
    {
        private readonly Contexto contexto;

        public PublicacionesBLL(Contexto _contexto)
        {
            this.contexto = _contexto;
        }

        public bool Existe(int idPublicacion)
        {
            bool encontrado = false;
            try
            {
                encontrado = contexto.Publicaciones.Any(x => x.IdPublicacion == idPublicacion);
            }
            catch (Exception)
            {

                throw;
            }
            return encontrado;
        }

        public async Task<List<Publicaciones>> GetListAsync(Expression<Func<Publicaciones, bool>> criterio)
        {
            List<Publicaciones> lista = new List<Publicaciones>();

            try
            {
                lista = contexto.Publicaciones.Where(criterio).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            return lista;
        }

        public async Task<Publicaciones> GetPublicacion(int id)
        {
            Publicaciones publicacion = new Publicaciones();
            try
            {
                publicacion = await contexto.Publicaciones.Where(x => x.IdPublicacion == id)
                    .FirstAsync();
            }
            catch (Exception)
            {

                throw;
            }
            return publicacion;
        }

        public async Task<Publicaciones> GetPublicacionDetallada(int id)
        {
            Publicaciones publicacion = new Publicaciones();
            try
            {
                publicacion = await contexto.Publicaciones
                    .Where(x => x.IdPublicacion == id)
                    .Include(x => x.Etiqueta)
                    .Include(x => x.Estado)
                    .AsNoTracking()
                    .FirstAsync();
            }
            catch (Exception)
            {

                throw;
            }
            return publicacion;
        }

        public async Task<List<Publicaciones>> GetPublicaciones()
        {
            List<Publicaciones> lista = new List<Publicaciones>();

            try
            {
                lista = await contexto.Publicaciones.AsNoTracking().ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
            return lista;
        }

        public async Task<bool> Guardar(Publicaciones publicacion)
        {
            if (Existe(publicacion.IdPublicacion)){
                return await Modificar(publicacion);
            }
            else
            {
                return await Insertar(publicacion);
            }
        }

        public async Task<bool> Insertar(Publicaciones publicacion)
        {
            bool paso = false;
            try
            {
                await contexto.Publicaciones.AddAsync(publicacion);
                paso = await contexto.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            return paso;
        }

        public async Task<bool> Modificar(Publicaciones publicacion)
        {
            bool paso = false;
            try
            {
                contexto.Publicaciones.Update(publicacion);
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
