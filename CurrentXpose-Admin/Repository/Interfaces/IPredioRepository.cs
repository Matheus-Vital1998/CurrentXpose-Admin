using CurrentXpose_Admin.Entidades;

namespace CurrentXpose_Admin.Repository.Interfaces
{
    public interface IPredioRepository : IBaseRepository<Predio>
    {
        Task<IReadOnlyList<Predio>> GetAll();
        Task Insert(Predio predio);
        Task Update(Predio predio);
        Task Delete(int predioId);
        Task<Predio> Details(int predioId);
    }
}
