using CurrentXpose_Admin.Entidades;

namespace CurrentXpose_Admin.Repository.Interfaces
{
    public interface ICondominioRepository : IBaseRepository<Condominio>
    {
        Task<IReadOnlyList<Condominio>> GetAll();
    }
}
