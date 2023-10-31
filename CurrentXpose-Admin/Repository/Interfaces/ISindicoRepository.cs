using CurrentXpose_Admin.Entidades;

namespace CurrentXpose_Admin.Repository.Interfaces
{
    public interface ISindicoRepository : IBaseRepository<Sindico>
    {
        Task<IReadOnlyList<Sindico>> GetAll();
    }
}
