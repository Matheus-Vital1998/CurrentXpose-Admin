using CurrentXpose_Admin.Entidades;

namespace CurrentXpose_Admin.Services.Interfaces
{
    public interface ICondominioService
    {
        Task<IReadOnlyList<Condominio>> ObterCondominios();
    }
}
