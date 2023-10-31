using CurrentXpose_Admin.Entidades;

namespace CurrentXpose_Admin.Repository.Interfaces
{
    public interface IMoradorRepository : IBaseRepository<Morador>
    {
        Task<IReadOnlyList<Morador>> GetAll();
        Task Insert(Morador novoMorador);
        Task Update(Morador moradorEditado);
        Task Delete(int moradorId);
        Task<Morador> Details(int moradorId);
    }
}
