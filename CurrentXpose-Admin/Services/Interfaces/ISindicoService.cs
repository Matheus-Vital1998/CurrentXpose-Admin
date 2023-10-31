using CurrentXpose_Admin.Entidades;

namespace CurrentXpose_Admin.Services.Interfaces
{
    public interface ISindicoService
    {
        Task<IReadOnlyList<Sindico>> ObterSindico();
    }
}
