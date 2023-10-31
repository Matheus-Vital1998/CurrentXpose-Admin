using CurrentXposeAPI.Entidades;

namespace CurrentXposeAPI.Services.Interfaces
{
    public interface ICondominioService
    {
        Task<IReadOnlyList<Condominio>> ObterCondominios();
    }
}
