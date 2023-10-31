using CurrentXpose_Admin.Domain.Entidades;

namespace CurrentXpose_Admin.Infra.Repository.Interfaces
{
    public interface IMoradorRepository : IBaseRepository<Morador>
    {
        Task<IReadOnlyList<Morador>> GetAll();
    }
}
