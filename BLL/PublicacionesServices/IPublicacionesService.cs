﻿using System.Linq.Expressions;
using TechTrendsAppv1.Modelos;

namespace TechTrendsAppv1.BLL.PublicacionesServices
{
    public interface IPublicacionesService
    {
        public bool Existe(int idPublicacion);
        public Task<bool> Guardar(Publicaciones publicacion);
        public Task<bool> Insertar(Publicaciones publicacion);
        public Task<bool> Modificar(Publicaciones publicacion);
        public Task<bool> Eliminar(Publicaciones publicacion);
        public Task<List<Publicaciones>> GetPublicaciones();
        public Task<List<Publicaciones>> GetPublicacionesPublicada();
        public Task<Publicaciones> GetPublicacion(int id);
        public Task<Publicaciones> GetPublicacionDetallada(int id);
        public Task<List<Publicaciones>> GetListAsync(Expression<Func<Publicaciones, bool>> criterio);

    }
}
