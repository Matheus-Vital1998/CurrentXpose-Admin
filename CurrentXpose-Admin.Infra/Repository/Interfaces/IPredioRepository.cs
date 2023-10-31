using CurrentXpose_Admin.Domain.Entidades;

namespace CurrentXpose_Admin.Infra.Repository.Interfaces
{
    public interface IPredioRepository : IBaseRepository<Predio>
    {
        Task<IReadOnlyList<Predio>> GetAll();
    }
}
