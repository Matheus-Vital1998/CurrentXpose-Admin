using CurrentXpose_Admin.Entidades;

namespace CurrentXpose_Admin.Repository.Interfaces
{
    public interface IMoradorRepository : IBaseRepository<Morador>
    {
        Task<IReadOnlyList<Morador>> GetAll();
    }
}
