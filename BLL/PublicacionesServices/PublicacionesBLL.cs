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

        public Task<bool> Modificar(Publicaciones publicacion)
        {
            throw new NotImplementedException();
        }
    }
}
