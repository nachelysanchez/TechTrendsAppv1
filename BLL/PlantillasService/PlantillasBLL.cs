using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using TechTrendsAppv1.DAL;
using TechTrendsAppv1.Modelos;

namespace TechTrendsAppv1.BLL.PlantillasService
{
    public class PlantillasBLL : IPlantillasService
    {
        private readonly Contexto contexto;

        public PlantillasBLL(Contexto _contexto)
        {
            this.contexto = _contexto;
        }
        public bool Existe(int idplantilla)
        {
            bool encontrado = false;
            try
            {
                encontrado = contexto.Plantillas.Any(x => x.IdPlantilla == idplantilla);
            }
            catch (Exception)
            {

                throw;
            }
            return encontrado;
        }

        public async Task<List<Plantillas>> GetListAsync(Expression<Func<Plantillas, bool>> criterio)
        {
            List<Plantillas> lista = new List<Plantillas>();

            try
            {
                lista = await contexto.Plantillas.Where(criterio).AsNoTracking().ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
            return lista;
        }

        public async Task<List<Plantillas>> GetPlantillas()
        {
            List<Plantillas> lista = new List<Plantillas>();

            try
            {
                lista = await contexto.Plantillas.AsNoTracking().ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
            return lista;
        }

        public async Task<bool> Guardar(Plantillas plantilla)
        {
            if (Existe(plantilla.IdPlantilla))
            {
                return await Modificar(plantilla);
            }
            else
            {
                return await Insertar(plantilla);
            }
        }

        public async Task<bool> Insertar(Plantillas plantilla)
        {
            bool paso = false;
            try
            {
                await contexto.Plantillas.AddAsync(plantilla);
                paso = await contexto.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            return paso;
        }

        public async Task<bool> Modificar(Plantillas plantilla)
        {
            bool paso = false;
            try
            {
                contexto.Plantillas.Update(plantilla);
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
