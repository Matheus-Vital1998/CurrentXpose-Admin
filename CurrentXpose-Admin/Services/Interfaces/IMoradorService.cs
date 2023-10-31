using CurrentXpose_Admin.Entidades;

namespace CurrentXpose_Admin.Services.Interfaces
{
    public interface IMoradorService
    {
        Task<IReadOnlyList<Morador>> ObterMoradores();
    }
}
