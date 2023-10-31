using CurrentXpose_Admin.Entidades;

namespace CurrentXpose_Admin.Services.Interfaces
{
    public interface IResidenciaService
    {
        Task<IReadOnlyList<Residencia>> ObterResidencias();
    }
}
