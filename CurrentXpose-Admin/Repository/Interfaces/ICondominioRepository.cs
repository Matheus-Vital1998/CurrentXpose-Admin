using CurrentXpose_Admin.Entidades;

namespace CurrentXpose_Admin.Repository.Interfaces
{
    public interface ICondominioRepository : IBaseRepository<Condominio>
    {
        Task<IReadOnlyList<Condominio>> GetAll();
        Task Insert(Condominio condominio);
        Task Update(Condominio condominio);
        Task Delete(int condominioId);
        Task<Condominio> Details(int condominioId);
    }
}
