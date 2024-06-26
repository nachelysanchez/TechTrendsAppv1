﻿using System.Linq.Expressions;
using TechTrendsAppv1.Modelos;

namespace TechTrendsAppv1.BLL.UsuariosServices
{
    public interface IUsuariosService
    {
        public Task<Usuarios> Login(string email, string clave);
        public Task<Usuarios> GetUsuario(int idUsuario);
        public Task<Usuarios> GetUsuarioLogueado();
        public void CerrarSesion();

        public Task<List<Usuarios>> GetUsuarios();
        public Task<List<Usuarios>> GetListAsync(Expression<Func<Usuarios, bool>> criterio);
        public Task<bool> ModificarUsuario(Usuarios usuario);
        public Task<bool> RegistrarUsuario(Usuarios usuario);
    }
}
