using TechTrendsAppv1.Modelos;

namespace TechTrendsAppv1.BLL.PublicacionesServices
{
    public interface IPublicacionesService
    {
        public bool Existe(int idPublicacion);
        public Task<bool> Guardar(Publicaciones publicacion);
        public Task<bool> Insertar(Publicaciones publicacion);
        public Task<bool> Modificar(Publicaciones publicacion);
    }
}
