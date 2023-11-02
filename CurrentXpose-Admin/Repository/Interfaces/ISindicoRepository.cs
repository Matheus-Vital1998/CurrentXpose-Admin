using CurrentXpose_Admin.Entidades;

namespace CurrentXpose_Admin.Repository.Interfaces
{
    public interface ISindicoRepository : IBaseRepository<Sindico>
    {
        Task<IReadOnlyList<Sindico>> GetAll();
        Task Insert(Sindico sindico);
        Task<bool> Update(Sindico sindico);
        Task<bool> Delete(int sindicoId);
        Task<Sindico> Details(int sindicoId);
    }
}
