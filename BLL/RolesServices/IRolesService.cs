using TechTrendsAppv1.Modelos;

namespace TechTrendsAppv1.BLL.RolesServices
{
    public interface IRolesService
    {
        Task<List<Modelos.Roles>> GetRolesAsync();
    }
}
