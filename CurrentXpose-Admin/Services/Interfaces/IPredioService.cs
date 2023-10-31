using CurrentXpose_Admin.Entidades;

namespace CurrentXpose_Admin.Services.Interfaces
{
    public interface IPredioService
    {
        Task<IReadOnlyList<Predio>> ObterPredios();
    }
}
