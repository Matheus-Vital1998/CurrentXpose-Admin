using CurrentXposeAPI.Entidades;

namespace CurrentXposeAPI.Services.Interfaces
{
    public interface IPredioService
    {
        Task<IReadOnlyList<Predio>> ObterPredios();
    }
}
