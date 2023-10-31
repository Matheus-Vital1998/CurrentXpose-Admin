using CurrentXpose_Admin.Entidades;

namespace CurrentXpose_Admin.Services.Interfaces
{
    public interface IPredioService
    {
        Task<IReadOnlyList<Predio>> ObterPredios();
        Task InserirPredio(Predio novoPredio);
        Task AtualizarPredio(Predio predioEditado);
        Task ExcluirPredio(int predioId);
        Task<Predio> DetalhesPredio(int predioId);
    }
}
