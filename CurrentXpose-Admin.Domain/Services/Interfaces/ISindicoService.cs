using CurrentXposeAPI.Entidades;

namespace CurrentXposeAPI.Services.Interfaces
{
    public interface ISindicoService
    {
        Task<IReadOnlyList<Sindico>> ObterSindico();
    }
}
