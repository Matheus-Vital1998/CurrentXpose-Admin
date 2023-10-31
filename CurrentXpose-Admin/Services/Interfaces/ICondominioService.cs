using CurrentXpose_Admin.Entidades;

namespace CurrentXpose_Admin.Services.Interfaces
{
    public interface ICondominioService
    {
        Task<IReadOnlyList<Condominio>> ObterCondominios();
        Task InserirCondominio(Condominio condominio);
        Task AtualizarCondominio(Condominio condominio);
        Task ExcluirCondominio(int condominioId);
        Task<Condominio> DetalhesCondominio(int condominioId);
    }
}
