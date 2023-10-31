using CurrentXpose_Admin.Domain.Entidades;

namespace CurrentXpose_Admin.Infra.Repository.Interfaces
{
    public interface ISindicoRepository : IBaseRepository<Sindico>
    {
        Task<IReadOnlyList<Sindico>> GetAll();
    }
}
