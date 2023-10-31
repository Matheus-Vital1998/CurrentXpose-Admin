using CurrentXposeAPI.Entidades;

namespace CurrentXposeAPI.Services.Interfaces
{
    public interface IResidenciaService
    {
        Task<IReadOnlyList<Residencia>> ObterResidencias();
    }
}
