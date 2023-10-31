using CurrentXpose_Admin.Entidades;

namespace CurrentXpose_Admin.Repository.Interfaces
{
    public interface IPredioRepository : IBaseRepository<Predio>
    {
        Task<IReadOnlyList<Predio>> GetAll();
    }
}
