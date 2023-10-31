using CurrentXpose_Admin.Domain.Entidades;

namespace CurrentXpose_Admin.Infra.Repository.Interfaces
{
    public interface ICondominioRepository : IBaseRepository<Condominio>
    {
        Task<IReadOnlyList<Condominio>> GetAll();
    }
}
